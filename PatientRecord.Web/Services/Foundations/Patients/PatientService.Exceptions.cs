using EFxceptions.Models.Exceptions;
using PatientRecord.Web.Models.Doctors;
using PatientRecord.Web.Models.Doctors.Exceptions;
using PatientRecord.Web.Models.Patients;
using PatientRecord.Web.Models.Patients.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xeptions;

namespace PatientRecord.Web.Services.Foundations.Patients
{
    public partial class PatientService
    {
        private delegate ValueTask<Patient> ReturningPatientFunction();
        private delegate IQueryable<Patient> ReturningPatientsFunction();
        private async ValueTask<Patient> TryCatch(ReturningPatientFunction returningPatientFunction)
        {
            try
            {
                return await returningPatientFunction();
            }
            catch (NullPatientException nullPatientException)
            {
                throw CreateAndLogValidationException(nullPatientException);
            }
            catch (InvalidPatientException invalidPatientException)
            {
                throw CreateAndLogValidationException(invalidPatientException);
            }
            catch (NotFoundPatientException potFoundPatientException)
            {
                throw CreateAndLogValidationException(potFoundPatientException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsPatientException =
                    new AlreadyExistsPatientException(duplicateKeyException);

                throw CreateAndDependencyValidationException(alreadyExistsPatientException);
            }
            catch (Exception serviceException)
            {
                var patientServiceException =
                    new PatientServiceException(serviceException);

                throw CreateAndLogServiceException(patientServiceException);
            }
        }

        private IQueryable<Patient> TryCatch(ReturningPatientsFunction returningPatientsFunction)
        {
            try
            {
                return returningPatientsFunction();
            }
            catch (Exception serviceException)
            {
                var patientServiceException =
                    new PatientServiceException(serviceException);

                throw CreateAndLogServiceException(patientServiceException);
            }
        }

        private PatientServiceException CreateAndLogServiceException(Exception innerException)
        {
            this.loggingBroker.LogError(innerException);

            throw innerException;
        }

        private PatientDependencyValidationException CreateAndDependencyValidationException(Xeption exception)
        {

            var patientDependencyValidationException =
                new PatientDependencyValidationException(exception);

            this.loggingBroker.LogCritical(patientDependencyValidationException);

            return patientDependencyValidationException;
        }

        private PatientValidationException CreateAndLogValidationException(Xeption exception)
        {
            var patientValidationException =
                new PatientValidationException(exception);

            this.loggingBroker.LogError(patientValidationException);

            return patientValidationException;

        }
    }
}


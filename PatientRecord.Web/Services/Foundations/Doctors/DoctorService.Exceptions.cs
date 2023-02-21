using EFxceptions.Models.Exceptions;
using PatientRecord.Web.Models.Doctors;
using PatientRecord.Web.Models.Doctors.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xeptions;

namespace PatientRecord.Web.Services.Foundations.Doctors
{
    public partial class DoctorService
    {
        private delegate ValueTask<Doctor> ReturningDoctorFunction();
        private delegate IQueryable<Doctor> ReturningDoctorsFunction();
        private async ValueTask<Doctor> TryCatch(ReturningDoctorFunction returningDoctorFunction)
        {
            try
            {
                return await returningDoctorFunction();
            }
            catch (NullDoctorException nullDoctorException)
            {
                throw CreateAndLogValidationException(nullDoctorException);
            }
            catch (InvalidDoctorException invalidDoctorException)
            {
                throw CreateAndLogValidationException(invalidDoctorException);
            }
            catch (NotFoundDoctorException notFoundDoctorException)
            {
                throw CreateAndLogValidationException(notFoundDoctorException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsDoctorException =
                    new AlreadyExistsDoctorException(duplicateKeyException);

                throw CreateAndDependencyValidationException(alreadyExistsDoctorException);
            }
            catch (Exception serviceException)
            {
                var doctorServiceException =
                    new DoctorServiceException(serviceException);

                throw CreateAndLogServiceException(doctorServiceException);
            }
        }

        private IQueryable<Doctor> TryCatch(ReturningDoctorsFunction returningDoctorsFunction)
        {
            try
            {
                return returningDoctorsFunction();
            }
            catch (Exception serviceException)
            {
                var doctorServiceException =
                    new DoctorServiceException(serviceException);

                throw CreateAndLogServiceException(doctorServiceException);
            }
        }

        private DoctorServiceException CreateAndLogServiceException(Exception innerException)
        {
            this.loggingBroker.LogError(innerException);

            throw innerException;
        }

        private DoctorDependencyValidationException CreateAndDependencyValidationException(Xeption exception)
        {

            var doctorDependencyValidationException =
                new DoctorDependencyValidationException(exception);

            this.loggingBroker.LogCritical(doctorDependencyValidationException);

            return doctorDependencyValidationException;
        }

        private DoctorValidationException CreateAndLogValidationException(Xeption exception)
        {
            var doctorValidationException =
                new DoctorValidationException(exception);

            this.loggingBroker.LogError(doctorValidationException);

            return doctorValidationException;

        }
    }
}

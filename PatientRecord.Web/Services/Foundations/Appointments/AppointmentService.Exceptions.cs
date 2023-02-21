using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
using PatientRecord.Web.Models.Appointments;
using PatientRecord.Web.Models.Appointments.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xeptions;

namespace PatientRecord.Web.Services.Foundations.Appointments
{
    public partial class AppointmentService
    {
        private delegate ValueTask<Appointment> ReturningAppointmentFunction();
        private delegate IQueryable<Appointment> ReturningAppointmentsFunction();

        private async ValueTask<Appointment>TryCatch(ReturningAppointmentFunction returningAppointmentFunction)
        {
            try
            {
                return await returningAppointmentFunction();
            }
            catch(NullAppointmentException nullAppointmentException)
            {
                throw CreateAndLogValidationException(nullAppointmentException);
            }
            catch(InvalidAppointmentException invalidAppointmentException)
            {
                throw CreateAndLogValidationException(invalidAppointmentException);
            }
            catch(NotFoundAppointmentException notFoundAppointmentException)
            {
                throw CreateAndLogValidationException(notFoundAppointmentException);
            }
            catch(DuplicateKeyException  duplicateKeyException)
            {
                var alreadyExistsAppointmentException =
                    new AlreadyExistsAppointmentException(duplicateKeyException);
               
                throw CreateAndDependencyValidationException(alreadyExistsAppointmentException);
            }
            catch (Exception serviceException)
            {
                var appointmentServiceException =
                    new AppointmentServiceException(serviceException);

                throw CreateAndLogServiceException(appointmentServiceException);
            }
        }

        private IQueryable<Appointment>TryCatch(ReturningAppointmentsFunction returningAppointmentsFunction)
        {
            try
            {
                return returningAppointmentsFunction();
            }
            catch (Exception serviceException)
            {
                var appointmentServiceException =
                    new AppointmentServiceException(serviceException);

                throw CreateAndLogServiceException(appointmentServiceException);
            }
        }

        private AppointmentServiceException CreateAndLogServiceException(Exception innerException)
        {
            this.loggingBroker.LogError(innerException);

            throw innerException;
        }

        private AppointmentDependencyValidationException CreateAndDependencyValidationException(AlreadyExistsAppointmentException alreadyExistsAppointmentException)
        {

            var appointmentDependencyValidationException =
                new AppointmentDependencyValidationException(alreadyExistsAppointmentException);

            this.loggingBroker.LogCritical(appointmentDependencyValidationException);

            return appointmentDependencyValidationException;
        }

        private AppointmentValidationException CreateAndLogValidationException(Xeption exception)
        {
            var appointmentValidationException = 
                new AppointmentValidationException(exception);

            this.loggingBroker.LogError(appointmentValidationException);

            return appointmentValidationException;
            
        }
    }
}

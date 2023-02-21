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
        }

        private Exception CreateAndLogValidationException(Xeption exception)
        {
            throw new NotImplementedException();
        }
    }
}

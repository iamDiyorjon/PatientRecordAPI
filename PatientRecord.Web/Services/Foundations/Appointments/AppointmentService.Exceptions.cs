using PatientRecord.Web.Models.Appointments;
using PatientRecord.Web.Models.Appointments.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        }

        private Exception CreateAndLogValidationException(NullAppointmentException nullAppointmentException)
        {
            throw new NotImplementedException();
        }
    }
}

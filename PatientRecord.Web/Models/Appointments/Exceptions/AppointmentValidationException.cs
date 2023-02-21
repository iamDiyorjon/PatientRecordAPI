using Xeptions;

namespace PatientRecord.Web.Models.Appointments.Exceptions
{
    public class AppointmentValidationException : Xeption
    {
        public AppointmentValidationException(Xeption innerException)
            : base(message: "Appointment validation error occured, fix the errors and try again.",
                 innerException: innerException)
        { }
    }
}

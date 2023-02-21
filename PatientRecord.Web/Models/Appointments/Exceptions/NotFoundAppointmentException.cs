using System;
using Xeptions;

namespace PatientRecord.Web.Models.Appointments.Exceptions
{
    public class NotFoundAppointmentException : Xeption
    {
        public NotFoundAppointmentException(Guid appointmentId)
            : base(message: $"Could not find user with id:{appointmentId}.")
        { }
    }
}

using System;
using Xeptions;

namespace PatientRecord.Web.Models.Appointments.Exceptions
{
    public class AlreadyExistsAppointmentException :Xeption
    {
        public AlreadyExistsAppointmentException(Exception innerException)
            : base(message: "Appointment already exists",
                 innerException: innerException)
        { }
    }
}

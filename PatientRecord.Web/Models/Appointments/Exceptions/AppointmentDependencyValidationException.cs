using System;
using Xeptions;

namespace PatientRecord.Web.Models.Appointments.Exceptions
{
    public class AppointmentDependencyValidationException :Xeption
    {
        public AppointmentDependencyValidationException(Xeption innerException)
            : base (message: "Appointment dependency validation error occurred, fix the error and try again ",
                  innerException)
        { }
    }
}

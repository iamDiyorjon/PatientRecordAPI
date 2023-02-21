using System;
using Xeptions;

namespace PatientRecord.Web.Models.Appointments.Exceptions
{
    public class AppointmentServiceException :Xeption
    {
        public AppointmentServiceException(Exception innerException)
            : base(message: "Appointment service error occured, contact support.",
                  innerException)
        { }
    }
}

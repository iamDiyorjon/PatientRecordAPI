using System;
using Xeptions;

namespace PatientRecord.Web.Models.Doctors.Exceptions
{
    public class DoctorServiceException : Xeption
    {
        public DoctorServiceException(Exception innerException)
             : base(message: "Appointment service error occured, contact support.", innerException)
        { }
    }
}

using System;
using Xeptions;

namespace PatientRecord.Web.Models.Doctors.Exceptions
{
    public class AlreadyExistsDoctorException : Xeption
    {
        public AlreadyExistsDoctorException(Exception innerException)
            : base(message: "Doctor already exists", innerException: innerException)
        { }
    }
}

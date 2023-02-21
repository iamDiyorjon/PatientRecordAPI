using Xeptions;

namespace PatientRecord.Web.Models.Doctors.Exceptions
{
    public class InvalidDoctorException : Xeption
    {
        public InvalidDoctorException()
              : base(message: "Doctor is invalid")
        { }
    }
}

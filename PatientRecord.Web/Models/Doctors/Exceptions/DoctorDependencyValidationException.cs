using Xeptions;

namespace PatientRecord.Web.Models.Doctors.Exceptions
{
    public class DoctorDependencyValidationException : Xeption
    {
        public DoctorDependencyValidationException(Xeption innerException)
            : base(message: "Doctor dependency validation error occurred, fix the error and try again ",
                  innerException)
        { }
    }
}

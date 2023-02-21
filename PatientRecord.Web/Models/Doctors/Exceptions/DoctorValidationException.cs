using Xeptions;

namespace PatientRecord.Web.Models.Doctors.Exceptions
{
    public class DoctorValidationException : Xeption
    {
        public DoctorValidationException(Xeption innerException)
            : base(message: "Doctor validation error occured, fix the errors and try again.",
                 innerException)
        { }
    }
}

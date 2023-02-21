using Xeptions;

namespace PatientRecord.Web.Models.Patients.Exceptions
{
    public class PatientValidationException : Xeption
    {
        public PatientValidationException(Xeption innerException)
            : base(message: "Patient validation error occured, fix the errors and try again.",
                 innerException)
        { }
    }
}

using Xeptions;

namespace PatientRecord.Web.Models.Patients.Exceptions
{
    public class PatientDependencyValidationException : Xeption
    {
        public PatientDependencyValidationException(Xeption innerException)
            : base(message: "Patient dependency validation error occurred, fix the error and try again ",
                  innerException)
        { }
    }
}

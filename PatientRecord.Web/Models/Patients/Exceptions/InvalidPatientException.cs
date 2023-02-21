using Xeptions;

namespace PatientRecord.Web.Models.Patients.Exceptions
{
    public class InvalidPatientException : Xeption
    {
        public InvalidPatientException()
              : base(message: "Patient is invalid")
        { }
    }
}

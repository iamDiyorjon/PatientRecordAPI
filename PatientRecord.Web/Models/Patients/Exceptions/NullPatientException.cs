using Xeptions;

namespace PatientRecord.Web.Models.Patients.Exceptions
{
    public class NullPatientException : Xeption
    {
        public NullPatientException()
            : base(message: "Patient is null")
        { }
    }
}

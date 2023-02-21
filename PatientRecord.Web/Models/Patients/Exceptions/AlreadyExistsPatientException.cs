using System;
using Xeptions;

namespace PatientRecord.Web.Models.Patients.Exceptions
{
    public class AlreadyExistsPatientException : Xeption
    {
        public AlreadyExistsPatientException(Exception innerException)
            : base(message: "Patient already exists", innerException: innerException)
        { }
    }
}

using System;
using Xeptions;

namespace PatientRecord.Web.Models.Patients.Exceptions
{
    public class NotFoundPatientException : Xeption
    {
        public NotFoundPatientException(Guid patientId)
            : base(message: $"Could not find patient with id:{patientId}.")
        { }
    }
}

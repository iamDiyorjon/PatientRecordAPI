using System;
using Xeptions;

namespace PatientRecord.Web.Models.Patients.Exceptions
{
    public class PatientServiceException : Xeption
    {
        public PatientServiceException(Exception innerException)
             : base(message: "Patient service error occured, contact support.", innerException)
        { }
    }
}

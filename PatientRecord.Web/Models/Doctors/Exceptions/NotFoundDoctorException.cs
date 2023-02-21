using System;
using Xeptions;

namespace PatientRecord.Web.Models.Doctors.Exceptions
{
    public class NotFoundDoctorException : Xeption
    {
        public NotFoundDoctorException(Guid doctorId)
            : base(message: $"Could not find doctor with id:{doctorId}.")
        { }
    }
}

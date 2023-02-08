using Xeptions;

namespace PatientRecord.Web.Models.Appointments.Exceptions
{
    public class NullAppointmentException :Xeption
    {
        public NullAppointmentException()
            :base(message:"Appointment is null")
        { }
    }
}

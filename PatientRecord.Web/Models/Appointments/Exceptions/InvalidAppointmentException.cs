using Xeptions;

namespace PatientRecord.Web.Models.Appointments.Exceptions
{
    public class InvalidAppointmentException : Xeption
    {
        public InvalidAppointmentException() 
            :base (message:"Appointment is invalid")
        { }
    }
}

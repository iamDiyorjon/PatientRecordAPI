using PatientRecord.Web.Models.Appointments;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecord.Web.Services.Foundations.Appoinments
{
    public interface IAppointmentService
    {
        ValueTask<Appointment> AddAppointmentAsync(Appointment appointment);
        IQueryable<Appointment> RetriveAllAppointments();
        ValueTask<Appointment> RetriveAppointmentByIdAsync(Guid id);
        ValueTask<Appointment> ModifyAppointmentAsync(Appointment appointment);
        ValueTask<Appointment> RemoveAppointmentByIdAsync(Guid id);
    }
}

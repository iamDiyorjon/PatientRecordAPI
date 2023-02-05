using PatientRecord.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecord.Web.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Appointment>InsertAppointmentAsync(Appointment appointment);
        IQueryable<Appointment> SelectAllAppoinment();
        ValueTask<Appointment> SelectAppointmentByIdAsync(Guid id);
        ValueTask<Appointment>UpdateAppointmentAsync(Appointment appointment);
        ValueTask<Appointment> DeleteAppointmentAsync(Appointment appointment);
    
    }
}

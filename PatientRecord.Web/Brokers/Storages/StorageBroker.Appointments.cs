using Microsoft.EntityFrameworkCore;
using PatientRecord.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecord.Web.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Appointment> Appointments { get; set; }

        public async ValueTask<Appointment> InsertAppointmentAsync(Appointment appointment) =>
            await InsertAsync(appointment);

        public IQueryable<Appointment> SelectAllAppoinment() =>
            SelectAll<Appointment>();

        public async ValueTask<Appointment> SelectAppointmentByIdAsync(Guid id) =>
          await SelectAsync<Appointment>(id);

        public async ValueTask<Appointment> UpdateAppointmentAsync(Appointment appointment) =>
            await UpdateAsync(appointment);

        public async ValueTask<Appointment> DeleteAppointmentAsync(Appointment appointment) =>
            await DeleteAsync(appointment);
    }
}

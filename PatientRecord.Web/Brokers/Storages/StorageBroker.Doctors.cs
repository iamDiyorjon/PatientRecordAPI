using Microsoft.EntityFrameworkCore;
using PatientRecord.Web.Models;
using PatientRecord.Web.Models.Doctors;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecord.Web.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Doctor> Doctors { get; set; }

        public async ValueTask<Doctor> InsertDoctorAsync(Doctor doctor) =>
            await InsertAsync<Doctor>(doctor);

        public IQueryable<Doctor> SelectAllDoctor() =>
            SelectAll<Doctor>();

        public async ValueTask<Doctor> SelectDoctorByIdAsync(Guid id) =>
            await SelectAsync<Doctor>(id);

        public async ValueTask<Doctor> UpdateDoctorAsync(Doctor doctor) =>
            await UpdateAsync<Doctor>(doctor);

        public async ValueTask<Doctor> DeleteDoctorAsync(Doctor doctor) =>
            await DeleteAsync<Doctor>(doctor);
    }
}

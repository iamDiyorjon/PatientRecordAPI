using Microsoft.EntityFrameworkCore;
using PatientRecord.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecord.Web.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Patient> Patients { get; set; }

        public async ValueTask<Patient> InsertPatientAsync(Patient patient) =>
            await InsertAsync(patient);

        public IQueryable<Patient> SelectAllPatient() =>
            SelectAll<Patient>();

        public async ValueTask<Patient> SelectPatientByIdAsync(Guid id) =>
            await SelectAsync<Patient>(id);

        public async ValueTask<Patient> UpdatePatientAsync(Patient patient) =>
            await UpdateAsync(patient);

        public async ValueTask<Patient> DeletePatientAsync(Patient patient) =>
            await DeleteAsync(patient);
    }
}

using PatientRecord.Web.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace PatientRecord.Web.Brokers.Storages
{
    public  partial interface IStorageBroker
    {
        ValueTask<Patient> InsertPatientAsync(Patient patient);
        IQueryable<Patient> SelectAllPatient();
        ValueTask<Patient> SelectPatientByIdAsync(Guid id);
        ValueTask<Patient> UpdatePatientAsync(Patient patient);
        ValueTask<Patient> DeletePatientAsync(Patient patient);
    }
}

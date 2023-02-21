using System.Linq;
using System.Threading.Tasks;
using System;
using PatientRecord.Web.Models.Patients;

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

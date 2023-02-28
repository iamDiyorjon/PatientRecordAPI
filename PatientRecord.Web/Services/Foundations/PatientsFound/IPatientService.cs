using PatientRecord.Web.Models.Patients;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecord.Web.Services.Foundations.Patients
{
    public interface IPatientService
    {
        ValueTask<Patient> AddPatientAsync(Patient patient);
        IQueryable<Patient> RetriveAllPatients();
        ValueTask<Patient> RetrivePatientByIdAsync(Guid id);
        ValueTask<Patient> ModifyPatientAsync(Patient patient);
        ValueTask<Patient> RemovePatientByIdAsync(Guid id);
    }
}

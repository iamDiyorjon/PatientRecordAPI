using PatientRecord.Web.Models.Patients;
using System.Threading.Tasks;

namespace PatientRecord.Web.Services.Processings.PatientsProcess
{
    public interface IPatientProcessing
    {
        ValueTask<Patient> CreatePatientAsync(Patient patient);
    }
}

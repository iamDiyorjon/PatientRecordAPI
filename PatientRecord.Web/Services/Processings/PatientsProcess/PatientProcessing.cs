using PatientRecord.Web.Models.Patients;
using PatientRecord.Web.Services.Foundations.Patients;
using System.Threading.Tasks;

namespace PatientRecord.Web.Services.Processings.PatientsProcess
{
    public class PatientProcessing : IPatientProcessing
    {
        private readonly IPatientService patientService;

        public PatientProcessing(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        public async ValueTask<Patient> CreatePatientAsync(Patient patient)=>
            await patientService.AddPatientAsync(patient);
    }
}

using PatientRecord.Web.Services.DTOs;
using System.Threading.Tasks;

namespace PatientRecord.Web.Services.Processings.PatientProces;

public interface IPatientProcessingService
{
    public  ValueTask<PatientDTO> CreatPatientAsync(PatientDTO patientDTO);
    public ValueTask<PatientDTO> ModifyPatientAsync(PatientDTO patientDTO);
    public ValueTask<PatientDTO> RetrivePatientByPhoneNumberAsync(string phoneNumber);

}

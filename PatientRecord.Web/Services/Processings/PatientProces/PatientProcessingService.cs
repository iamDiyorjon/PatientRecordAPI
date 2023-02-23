using AutoMapper;
using PatientRecord.Web.Models.Patients;
using PatientRecord.Web.Services.DTOs;
using PatientRecord.Web.Services.Foundations.Patients;
using PatientRecord.Web.Services.Processings.PatientProces;
using System;
using System.Threading.Tasks;

namespace PatientRecord.Web.Services.Processings.Новая_папка
{
    public class PatientProcessingService: IPatientProcessingService
    {
        private readonly IMapper mapper;

        public PatientProcessingService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async ValueTask<PatientDTO> CreatPatientAsync(PatientDTO patientDTO)
        {
            
            throw new NotImplementedException();
        }

        public ValueTask<PatientDTO> ModifyPatientAsync(PatientDTO patientDTO)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<PatientDTO> RetrivePatientByPhoneNumberAsync(string phoneNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}

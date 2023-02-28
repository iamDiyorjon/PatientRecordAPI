using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PatientRecord.Web.Models.Patients;
using PatientRecord.Web.Services.DTOs;
using PatientRecord.Web.Services.Processings.PatientsProcess;
using RESTFulSense.Controllers;
using System;
using System.Threading.Tasks;

namespace PatientRecord.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : RESTFulController
    {
        private readonly IMapper mapper;
        private readonly IPatientProcessing patientProcessing;

        public PatientController(IMapper mapper, IPatientProcessing patientProcessing)
        {
            this.mapper = mapper;
            this.patientProcessing = patientProcessing;
        }

        [HttpPost]
        public async ValueTask<ActionResult<PatientDTO>> Create(PatientDTO patientDTO)
        {
            try
            {
                Patient inputPatient = mapper.Map<Patient>(patientDTO);
                Patient addePatient = await patientProcessing.CreatePatientAsync(inputPatient);
                PatientDTO addedPatientDTO = mapper.Map<PatientDTO>(addePatient);
                return Ok(addedPatientDTO);

            }
            catch (Exception exception)
            {

                throw;
            }

        }
    }
}

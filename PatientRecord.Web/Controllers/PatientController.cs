using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientRecord.Web.Models.Patients;
using PatientRecord.Web.Services.DTOs;
using PatientRecord.Web.Services.Foundations.Patients;
using RESTFulSense.Controllers;
using System.Threading.Tasks;

namespace PatientRecord.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : RESTFulController
    {
        private readonly IPatientService patientService;
        private readonly IMapper mapper;
        public PatientController(IPatientService patient
            ,IMapper mapper)
        {

            this.mapper = mapper;
            this.patientService = patient;
        }

        [HttpPost]
        public async ValueTask<ActionResult<PatientDTO>> PostPatients(PatientDTO patientDTO)
        {
            try

            {
                var patient = mapper.Map<Patient>(patientDTO);

                var patients = await patientService.AddPatientAsync(patient);

                var pati = mapper.Map<PatientDTO>( patients);

                return Ok(pati);

            }
            catch (System.Exception)
            {

                throw;
            }
        }



    }
}

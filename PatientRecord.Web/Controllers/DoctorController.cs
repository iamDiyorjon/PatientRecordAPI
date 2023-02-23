using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientRecord.Web.Models.Doctors;
using PatientRecord.Web.Services.DTOs;
using PatientRecord.Web.Services.Foundations.Doctors;
using RESTFulSense.Controllers;
using System;
using System.Threading.Tasks;

namespace PatientRecord.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : RESTFulController
    {
        private readonly IDoctorService doctorService;
        private readonly IMapper mapper;
        public DoctorController(IDoctorService doctor
            , IMapper mapper)
        {

            this.mapper = mapper;
            this.doctorService = doctor;
        }

        [HttpPost]
        public async ValueTask<ActionResult<DoctorDTO>> PostPatients(DoctorDTO doctorDTO)
        {
            try

            {
                var doctorDatabase = mapper.Map<Doctor>(doctorDTO);

                var addedDoctor = await doctorService.AddDoctorAsync(doctorDatabase);

                var addedDTO = mapper.Map<DoctorDTO>(addedDoctor);

                return Ok(addedDTO);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpDelete("{doctorid}")]
        public async ValueTask<ActionResult<DoctorDTO>>GetByIdDoctor(Guid doctorid)
        {
            try
            {
                var storageDoctor = await doctorService.RetriveDoctorByIdAsync(doctorid);
                var doctorDTO=mapper.Map<DoctorDTO>(storageDoctor);
                return Ok(doctorDTO);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}


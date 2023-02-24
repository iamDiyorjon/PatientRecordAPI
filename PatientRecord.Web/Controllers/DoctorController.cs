using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpPut]
        public async ValueTask<ActionResult<DoctorDTO>>ModifyDoctorAsync(DoctorDTO doctorDTO)
        {
            try
            {
                var inputDoctor = mapper.Map<Doctor>(doctorDTO);

                inputDoctor.Id = Guid.Parse("3c9a4a09-9742-4e24-b3af-392f0f9d5914");

                var modifiedDoctor =await doctorService.ModifyDoctorAsync(inputDoctor);

                var outputDTO = mapper.Map<DoctorDTO>(modifiedDoctor);

                return Ok(outputDTO);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


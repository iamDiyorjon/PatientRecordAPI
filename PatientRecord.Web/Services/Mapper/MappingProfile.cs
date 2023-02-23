using AutoMapper;
using PatientRecord.Web.Models.Appointments;
using PatientRecord.Web.Models.Doctors;
using PatientRecord.Web.Models.Patients;
using PatientRecord.Web.Services.DTOs;

namespace PatientRecord.Web.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PatientDTO, Patient>();
            CreateMap<Patient, PatientDTO>();
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<DoctorDTO, Doctor>();
            CreateMap<Appointment, AppointmentDTO>();
            CreateMap<AppointmentDTO, Appointment>();
        }
    }
}

using AutoMapper;
using PatientRecord.Web.Models.Appointments;
using PatientRecord.Web.Models.Doctors;
using PatientRecord.Web.Models.Patients;

namespace PatientRecord.Web.Services.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppointmentDTO, Appointment>();
            CreateMap<Appointment, AppointmentDTO>();

            CreateMap<DoctorDTO, Doctor>();
            CreateMap<Doctor, DoctorDTO>();

            CreateMap<PatientDTO, Patient>();
            CreateMap<Patient, PatientDTO>();
        }
    }
}

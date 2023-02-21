using PatientRecord.Web.Models.Appointments;
using System.Linq;
using System.Threading.Tasks;
using System;
using PatientRecord.Web.Models.Doctors;

namespace PatientRecord.Web.Services.Foundations.Doctors
{
    public interface IDoctorService
    {
        ValueTask<Doctor> AddDoctorAsync(Doctor doctor);
        IQueryable<Doctor> RetriveAllDoctors();
        ValueTask<Doctor> RetriveDoctorByIdAsync(Guid id);
        ValueTask<Doctor> ModifyDoctorAsync(Doctor doctor);
        ValueTask<Doctor> RemoveDoctorByIdAsync(Guid id);
    }
}

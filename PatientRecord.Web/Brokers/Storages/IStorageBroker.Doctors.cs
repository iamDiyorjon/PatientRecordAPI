using System.Linq;
using System.Threading.Tasks;
using System;
using PatientRecord.Web.Models.Doctors;

namespace PatientRecord.Web.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Doctor> InsertDoctorAsync(Doctor doctor);
        IQueryable<Doctor> SelectAllDoctor();
        ValueTask<Doctor> SelectDoctorByIdAsync(Guid id);
        ValueTask<Doctor> UpdateDoctorAsync(Doctor doctor);
        ValueTask<Doctor> DeleteDoctorAsync(Doctor doctor);
    }
}

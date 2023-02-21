using PatientRecord.Web.Brokers.DataTimes;
using PatientRecord.Web.Brokers.Loggings;
using PatientRecord.Web.Brokers.Storages;
using PatientRecord.Web.Models.Appointments;
using System.Linq;
using System.Threading.Tasks;
using System;
using PatientRecord.Web.Models.Doctors;

namespace PatientRecord.Web.Services.Foundations.Doctors
{
    public partial class DoctorService :IDoctorService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public DoctorService(
            ILoggingBroker loggingBroker,
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.loggingBroker = loggingBroker;
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<Doctor> AddDoctorAsync(Doctor doctor) =>
        TryCatch(async () =>
        {
            ValidateDoctorOnAddAndModify(doctor);

            return await this.storageBroker.InsertDoctorAsync(doctor);
        });

        public IQueryable<Doctor> RetriveAllDoctors() =>
            TryCatch(() => this.storageBroker.SelectAllDoctor());

        public ValueTask<Doctor> RetriveDoctorByIdAsync(Guid id) =>
        TryCatch(async () =>
        {
            ValidateDoctorId(id);

            var maybeDoctor =
                await this.storageBroker.SelectDoctorByIdAsync(id);

            ValidateStorageDoctor(maybeDoctor, id);

            return maybeDoctor;
        });

        public ValueTask<Doctor> ModifyDoctorAsync(Doctor doctor) =>
        TryCatch(async () =>
        {
            ValidateDoctorOnAddAndModify(doctor);

            var maybeDoctor =
                await this.storageBroker.SelectDoctorByIdAsync(doctor.Id);

            ValidateStorageDoctor(maybeDoctor, doctor.Id);

            return await this.storageBroker.UpdateDoctorAsync(doctor);
        });

        public ValueTask<Doctor> RemoveDoctorByIdAsync(Guid id) =>
        TryCatch(async () =>
        {
            ValidateDoctorId(id);

            var maybeDoctor =
                await this.storageBroker.SelectDoctorByIdAsync(id);

            ValidateStorageDoctor(maybeDoctor, id);

            var result = await this.storageBroker.DeleteDoctorAsync(maybeDoctor);

            return result;
        });
    }
}

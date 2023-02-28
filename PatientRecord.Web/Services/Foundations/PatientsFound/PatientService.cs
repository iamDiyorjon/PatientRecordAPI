using PatientRecord.Web.Brokers.Loggings;
using PatientRecord.Web.Brokers.Storages;
using PatientRecord.Web.Models.Patients;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecord.Web.Services.Foundations.Patients
{
    public partial class PatientService : IPatientService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public PatientService(
            ILoggingBroker loggingBroker,
            IStorageBroker storageBroker)
        {
            this.loggingBroker = loggingBroker;
            this.storageBroker = storageBroker;
        }

        public ValueTask<Patient> AddPatientAsync(Patient patient) =>
        TryCatch(async () =>
        {
            ValidatePatientOnAddAndModify(patient);

            return await this.storageBroker.InsertPatientAsync(patient);
        });

        public IQueryable<Patient> RetriveAllPatients() =>
            TryCatch(() => this.storageBroker.SelectAllPatient());

        public ValueTask<Patient> RetrivePatientByIdAsync(Guid id) =>
        TryCatch(async () =>
        {
            ValidatePatientId(id);

            var maybePatient =
                await this.storageBroker.SelectPatientByIdAsync(id);

            ValidateStoragePatient(maybePatient, id);

            return maybePatient;
        });

        public ValueTask<Patient> ModifyPatientAsync(Patient patient) =>
        TryCatch(async () =>
        {
            ValidatePatientOnAddAndModify(patient);

            var maybePatient =
                await this.storageBroker.SelectPatientByIdAsync(patient.Id);

            ValidateStoragePatient(maybePatient, patient.Id);

            return await this.storageBroker.UpdatePatientAsync(patient);
        });

        public ValueTask<Patient> RemovePatientByIdAsync(Guid id) =>
        TryCatch(async () =>
        {
            ValidatePatientId(id);

            var maybePatient =
                await this.storageBroker.SelectPatientByIdAsync(id);

            ValidateStoragePatient(maybePatient, id);

            var result = await this.storageBroker.DeletePatientAsync(maybePatient);

            return result;
        });
    }
}

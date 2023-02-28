using PatientRecord.Web.Brokers.Loggings;
using PatientRecord.Web.Brokers.Storages;
using PatientRecord.Web.Models.Appointments;
using PatientRecord.Web.Services.Foundations.Appoinments;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecord.Web.Services.Foundations.Appointments
{
    public partial class AppointmentService : IAppointmentService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        public AppointmentService(
            ILoggingBroker loggingBroker,
            IStorageBroker storageBroker)
        {
            this.loggingBroker = loggingBroker;
            this.storageBroker = storageBroker;
        }

        public ValueTask<Appointment> AddAppointmentAsync(Appointment appointment) =>
        TryCatch(async () =>
        {
            ValidateAppointmentOnAddAndModify(appointment);

            return await this.storageBroker.InsertAppointmentAsync(appointment);
        });

        public IQueryable<Appointment> RetriveAllAppointments() =>
            TryCatch(() => this.storageBroker.SelectAllAppoinment());

        public ValueTask<Appointment> RetriveAppointmentByIdAsync(Guid id) =>
        TryCatch(async () =>
        {
            ValidateAppointmentId(id);

            var maybeAppointment =
                await this.storageBroker.SelectAppointmentByIdAsync(id);

            ValidateStorageAppointment(maybeAppointment, id);

            return maybeAppointment;
        });

        public ValueTask<Appointment> ModifyAppointmentAsync(Appointment appointment) =>
        TryCatch(async () =>
        {
            ValidateAppointmentOnAddAndModify(appointment);

            var maybeApponiment =
                await this.storageBroker.SelectAppointmentByIdAsync(appointment.Id);

            ValidateStorageAppointment(maybeApponiment, appointment.Id);

            return await this.storageBroker.UpdateAppointmentAsync(appointment);
        });

        public ValueTask<Appointment> RemoveAppointmentByIdAsync(Guid id) =>
        TryCatch(async () =>
        {
            ValidateAppointmentId(id);

            var maybeAppointment =
                await this.storageBroker.SelectAppointmentByIdAsync(id);

            ValidateStorageAppointment(maybeAppointment, id);

            var result = await this.storageBroker.DeleteAppointmentAsync(maybeAppointment);

            return result;
        });
    }
}

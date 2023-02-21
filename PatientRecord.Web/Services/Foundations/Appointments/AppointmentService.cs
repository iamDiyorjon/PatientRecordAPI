using PatientRecord.Web.Brokers.DataTimes;
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
        private readonly IDateTimeBroker dateTimeBroker;

        public AppointmentService(
            ILoggingBroker loggingBroker,
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.loggingBroker = loggingBroker;
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<Appointment> AddAppointmentAsync(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Appointment> ModifyAppointmentAsync(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Appointment> RemoveAppointmentByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Appointment> RetriveAllAppointments()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Appointment> RetriveAppointmentByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

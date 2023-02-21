using PatientRecord.Web.Models.Appointments;
using PatientRecord.Web.Models.Appointments.Exceptions;
using System;

namespace PatientRecord.Web.Services.Foundations.Appointments
{
    public partial class AppointmentService
    {
        private void ValidateAppointmentOnAddAndModify(Appointment appointment)
        {
            ValidateAppointmentNotNull(appointment);
            Validate(
                (Rule: IsInvalid(appointment.Id), Parameter: nameof(Appointment.Id)),
                (Rule: IsInvalid(appointment.DateOfMeeting), Parameter: nameof(Appointment.DateOfMeeting)),
                (Rule: IsInvalid(appointment.Patient_Id), Paremeter: nameof(Appointment.Patient_Id)),
                (Rule: IsInvalid(appointment.Doctor_Id), Paremeter: nameof(Appointment.Doctor_Id)));

        }

        private static dynamic IsInvalid(DateTime date) => new
        {
            Condition = date == default,
            Message = "Value is required"
        };

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == default,
            Message = "Id is required"
        };

        private static void ValidateStorageAppointment(Appointment maybeAppointment, Guid id)
        {
            if (maybeAppointment is null)
                throw new NotFoundAppointmentException(id);
        }


        private static void ValidateAppointmentNotNull(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new NullAppointmentException();
            }
        }

        private void ValidateAppointmentId(Guid id) =>
           Validate((Rule: IsInvalid(id), Parameter: nameof(Appointment.Id)));

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidAppointmentException = new InvalidAppointmentException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidAppointmentException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidAppointmentException.ThrowIfContainsErrors();
        }
    }
}

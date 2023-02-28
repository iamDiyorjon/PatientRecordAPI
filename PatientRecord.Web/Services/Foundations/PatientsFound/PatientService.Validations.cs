using PatientRecord.Web.Models.Patients;
using PatientRecord.Web.Models.Patients.Exceptions;
using System;

namespace PatientRecord.Web.Services.Foundations.Patients
{
    public partial class PatientService
    {
        private void ValidatePatientOnAddAndModify(Patient patient)
        {
            ValidatePatientNotNull(patient);
            Validate(
                (Rule: IsInvalid(patient.Id), Parameter: nameof(patient.Id)),
                (Rule: IsInvalid(patient.FirstName), Parameter: nameof(Patient.FirstName)),
                (Rule: IsInvalid(patient.PhoneNumber), Paremeter: nameof(Patient.PhoneNumber)),
                (Rule: IsInvalid(patient.Password), Paremeter: nameof(Patient.Password)),
                (Rule: IsInvalid(patient.Salt), Paremeter: nameof(Patient.Salt))
                );
        }

        private static dynamic IsInvalid(string text) => new
        {
            Condition = text == string.Empty,
            Message = "Text is required"
        };

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

        private static void ValidateStoragePatient(Patient patient, Guid id)
        {
            if (patient is null)
                throw new NotFoundPatientException(id);
        }

        private static void ValidatePatientNotNull(Patient patient)
        {
            if (patient == null)
            {
                throw new NullPatientException();
            }
        }

        private void ValidatePatientId(Guid id) =>
           Validate((Rule: IsInvalid(id), Parameter: nameof(Patient.Id)));

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidPatientException = new InvalidPatientException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidPatientException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidPatientException.ThrowIfContainsErrors();
        }
    }
}

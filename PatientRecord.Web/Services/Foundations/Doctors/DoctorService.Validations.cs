using PatientRecord.Web.Models.Doctors;
using PatientRecord.Web.Models.Doctors.Exceptions;
using System;

namespace PatientRecord.Web.Services.Foundations.Doctors
{
    public partial class DoctorService
    {
        private void ValidateDoctorOnAddAndModify(Doctor doctor)
        {
            ValidateDoctorNotNull(doctor);
            Validate(
                (Rule: IsInvalid(doctor.Id), Parameter: nameof(Doctor.Id)),
                (Rule: IsInvalid(doctor.FirstName), Parameter: nameof(Doctor.FirstName)),
                (Rule: IsInvalid(doctor.PhoneNumber), Paremeter: nameof(Doctor.PhoneNumber))
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

        private static void ValidateStorageDoctor(Doctor doctor, Guid id)
        {
            if (doctor is null)
                throw new NotFoundDoctorException(id);
        }

        private static void ValidateDoctorNotNull(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new NullDoctorException();
            }
        }

        private void ValidateDoctorId(Guid id) =>
           Validate((Rule: IsInvalid(id), Parameter: nameof(Doctor.Id)));

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidDoctorException = new InvalidDoctorException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidDoctorException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidDoctorException.ThrowIfContainsErrors();
        }
    }
}

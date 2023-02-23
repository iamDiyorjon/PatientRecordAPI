namespace PatientRecord.Web.Services.DTOs
{
    public record DoctorDTO(
        string firstName,
        string lastName,
        int age,
        string specialist,
        string phoneNumber);
}

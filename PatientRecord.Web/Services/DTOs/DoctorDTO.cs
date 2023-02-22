namespace PatientRecord.Web.Services.DTOs
{
    public record DoctorDTO(
        string fristName,
        string lastName,
        int age,
        string specialist,
        string phoneNumber );
}

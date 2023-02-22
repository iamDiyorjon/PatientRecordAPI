namespace PatientRecord.Web.Services.DTOs
{
    public record PatientDTO(
        string fristName,
        string lastName,
        int age,
        string email,
        string password,
        string phoneNumber); 
}

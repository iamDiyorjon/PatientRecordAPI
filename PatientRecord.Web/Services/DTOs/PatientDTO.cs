namespace PatientRecord.Web.Services.DTOs
{
    public record PatientDTO(
        string firstName,
        string lastName,
        int age,
        string email,
        string password,
        string phoneNumber); 
}

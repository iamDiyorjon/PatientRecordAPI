using System;

namespace PatientRecord.Web.Models;

public class Appointment
{
    public Guid Id { get; set; }
    public DateTime DateOfMeeting { get; set; }
    public DateTime? DateOfNextMeeting { get; set; }
    public string? Address { get; set; }
    public string? Diagnosis { get; set; }
    public string Recipe { get; set; }
    public string? Image { get; set; }
    public bool Active { get; set; } = true;
    public Patient Patient { get; set; }
    public int Patient_Id { get; set; }
    public Doctor Doctor { get; set; }
    public Guid Docotor_Id { get; set; }

}

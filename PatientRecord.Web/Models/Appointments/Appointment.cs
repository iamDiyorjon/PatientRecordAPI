using System;
using System.Collections.Generic;
using PatientRecord.Web.Models.Doctors;
using PatientRecord.Web.Models.Patients;

namespace PatientRecord.Web.Models.Appointments;

public class Appointment
{
    public Guid Id { get; set; }
    public DateTime DateOfMeeting { get; set; }
    public DateTime? DateOfNextMeeting { get; set; }
    public string Address { get; set; }
    public string Diagnosis { get; set; }
    public string Recipe { get; set; }

    /// <summary>
    /// Keyinchalik qo'shamiz
    /// </summary>
    //public IList<string> Image { get; set; }
    public bool Active { get; set; } = true;
    public Patient Patient { get; set; }
    public Guid Patient_Id { get; set; }
    public Doctor Doctor { get; set; }
    public Guid Doctor_Id { get; set; }

}

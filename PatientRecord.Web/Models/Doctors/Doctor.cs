using System;
using System.Collections.Generic;
using PatientRecord.Web.Models.Appointments;

namespace PatientRecord.Web.Models.Doctors;

public class Doctor
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string PhoneNumber { get; set; }
    public string Specialist { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
}

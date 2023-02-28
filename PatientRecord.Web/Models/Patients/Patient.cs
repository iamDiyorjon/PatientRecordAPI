using System;
using System.Collections.Generic;
using PatientRecord.Web.Models.Appointments;
using PatientRecord.Web.Models.Doctors;

namespace PatientRecord.Web.Models.Patients;

public class Patient
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; } = "salt";
    public string PhoneNumber { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
}

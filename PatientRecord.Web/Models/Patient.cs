using System;
using System.Collections.Generic;
using PatientRecord.Web.Models.Appointments;

namespace PatientRecord.Web.Models;

public class Patient
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
}

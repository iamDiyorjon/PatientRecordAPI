using System;
using System.Collections.Generic;

namespace PatientRecord.Web.Models;

public class Doctor
{
    public Guid ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string PhoneNumber { get; set; }
    public string Specialist { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
}

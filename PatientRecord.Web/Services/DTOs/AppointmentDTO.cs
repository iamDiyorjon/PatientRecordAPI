using PatientRecord.Web.Models.Patients;
using System;
using System.Collections.Generic;

namespace PatientRecord.Web.Services.DTOs
{
    public record AppointmentDTO(
        DateTime DateOfMeeting,
        DateTime? DateOfNextMeeting,
        string Address,
        string Diagnosis,
        string Recipe,
        IList<string> Image
        );
}
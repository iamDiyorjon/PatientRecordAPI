﻿using System;

namespace PatientRecord.Web.Models
{
    public class User
    {
        public Guid MyProperty { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
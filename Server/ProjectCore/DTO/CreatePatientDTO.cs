﻿using System;

namespace ProjectCore.DTO
{
    public class CreatePatientDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
    }
}
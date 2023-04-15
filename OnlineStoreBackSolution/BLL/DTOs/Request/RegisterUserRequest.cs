﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDAL.Enums;

namespace UserBLL.DTOs.Request
{
    public class RegisterUserRequest
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public DateTime BirthDay { get; set; }
        public string? Address { get; set; }   
        public Role Role { get; set; }
        public string? ProfilePhotoPath { get; set; }
    }
}

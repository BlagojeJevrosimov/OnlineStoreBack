﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDAL.Enums;

namespace UserBLL.DTOs.Response
{
    public class RegisterUserResponse
    {
        public int Id {get;set;}
        public string? JwtToken { get;set;}

        public Role Role { get;set;}
    }
}

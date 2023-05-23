using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBLL.DTOs.Response
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string? JwtToken { get; set; }
    }
}

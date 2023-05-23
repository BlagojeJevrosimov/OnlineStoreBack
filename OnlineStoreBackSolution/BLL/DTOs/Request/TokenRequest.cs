using Common.Enums;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBLL.DTOs.Request
{
    public class TokenRequest
    {
        public int Id { get; set; }
        public Role Role { get; set; }
    }
}

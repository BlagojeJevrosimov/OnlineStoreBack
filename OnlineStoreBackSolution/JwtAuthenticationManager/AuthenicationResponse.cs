using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthentificationManager
{
    public class AuthenicationResponse
    {
        public int Id {get;set;}
        public string? JwtToken { get;set;}

        public int? ExpiresIn { get;set;}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Auth.Requests
{
    public class AuthForLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

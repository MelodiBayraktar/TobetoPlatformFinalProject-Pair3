using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Auth.Responses
{
    public class AuthForLoginResponse
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

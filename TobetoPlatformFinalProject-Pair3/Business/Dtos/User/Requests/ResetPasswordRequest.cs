using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.User.Requests
{
    public class ResetPasswordRequest
    {
        public string Token { get; set; }
        public string Password { get; set; }

        //todo: validation yazılacak.
        [Required, Compare("Password")]
        public string ComfirmPassword { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.User.Responses
{
    public class ResetPasswordResponse
    {
        public string Token { get; set; }
        public string Password { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.PasswordReset.Requests
{
    public class UpdatePasswordResetRequest
    {
        public Guid? UserId { get; set; }
        public string? Password { get; set; }
        public string? RePassword { get; set; }

    }
}

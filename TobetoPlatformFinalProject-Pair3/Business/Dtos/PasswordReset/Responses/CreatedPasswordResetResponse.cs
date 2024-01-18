using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.PasswordReset.Responses
{
   public class CreatedPasswordResetResponse
    {
        public Guid? Id { get; set; }
        public string? VerificationCode { get; set; }
    }
}

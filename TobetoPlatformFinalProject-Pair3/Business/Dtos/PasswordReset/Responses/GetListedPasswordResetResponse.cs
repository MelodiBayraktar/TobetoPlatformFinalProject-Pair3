using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.PasswordReset.Responses
{
    public class GetListedPasswordResetResponse
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public string? VerificationCode { get; set; }
        public bool? IsUsed { get; set; }
    }
}

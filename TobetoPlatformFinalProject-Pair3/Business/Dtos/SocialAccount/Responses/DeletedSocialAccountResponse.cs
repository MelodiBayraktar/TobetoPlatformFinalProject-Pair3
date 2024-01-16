using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.SocialAccount.Responses
{
    public class DeletedSocialAccountResponse
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public string? Name { get; set; }
        public string? AccountUrl { get; set; }
    }
}

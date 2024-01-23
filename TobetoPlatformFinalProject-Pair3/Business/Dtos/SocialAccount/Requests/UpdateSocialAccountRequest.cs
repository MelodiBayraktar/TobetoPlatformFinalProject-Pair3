using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.SocialAccount.Requests
{
    public class UpdateSocialAccountRequest
    { 
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string AccountUrl { get; set; }
    }
}

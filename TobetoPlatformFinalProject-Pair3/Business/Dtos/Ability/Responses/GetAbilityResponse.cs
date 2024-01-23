using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Ability.Responses
{
    public class GetAbilityResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Ability.Requests;

public class CreateAbilityRequest
{
    public string? Name { get; set; }
    public Guid? UserId { get; set; }
}

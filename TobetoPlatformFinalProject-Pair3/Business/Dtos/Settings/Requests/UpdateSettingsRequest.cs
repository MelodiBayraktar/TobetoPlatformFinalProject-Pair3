using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Settings.Requests
{
    public class UpdateSettingsRequest
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
    }
}

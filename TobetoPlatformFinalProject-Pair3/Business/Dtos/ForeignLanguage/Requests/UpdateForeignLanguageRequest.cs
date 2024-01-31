using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.ForeignLanguage.Requests
{
    public class UpdateForeignLanguageRequest
    { 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LanguageLevel { get; set; }
    }
}

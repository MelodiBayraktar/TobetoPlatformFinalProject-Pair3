using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Education.Requests
{
    public class UpdateEducationRequest
    {
        public Guid Id { get; set; }
        public string EducationLevel { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        public DateTime StartDate { get; set; }
        public int GraduationYear { get; set; }
    }
}

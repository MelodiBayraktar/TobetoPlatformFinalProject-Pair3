using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Session.Responses
{
    public class GetSessionResponse
    {
        public Guid? Id { get; set; }
        public Guid? InstructorId { get; set; }
        public Guid? LiveContentId { get; set; }
        public string? Name { get; set; }    
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? RecordUrl { get; set; }
        public string? SessionLinkUrl { get; set; }
    }
}

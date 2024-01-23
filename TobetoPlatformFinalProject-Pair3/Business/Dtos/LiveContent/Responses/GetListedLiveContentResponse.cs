using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.LiveContent.Responses
{
    public class GetListedLiveContentResponse
    {
        public Guid Id { get; set;}
        public Guid LiveCourseId { get; set;}
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsContinue { get; set; }
    }
}

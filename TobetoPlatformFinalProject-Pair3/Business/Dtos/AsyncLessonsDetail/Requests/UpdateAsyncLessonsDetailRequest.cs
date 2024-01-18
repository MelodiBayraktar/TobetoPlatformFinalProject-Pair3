using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.AsyncLessonsDetail.Requests
{
    public class UpdateAsyncLessonsDetailRequest
    {
        public Guid? Id { get; set; }
        public bool? IsLiked { get; set; }
        public string? Category { get; set; }
        public string? Language { get; set; }
        public string? SubType { get; set; }
        public string? Description { get; set; }
        public string? ProducingCompany { get; set; }
    }
}

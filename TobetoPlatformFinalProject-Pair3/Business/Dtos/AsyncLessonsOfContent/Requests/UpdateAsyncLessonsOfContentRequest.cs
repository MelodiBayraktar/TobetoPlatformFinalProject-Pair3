using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.AsyncLessonsOfContent.Requests
{
    public class UpdateAsyncLessonsOfContentRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Duration { get; set; }
        public bool IsCompleted { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        
    }
}

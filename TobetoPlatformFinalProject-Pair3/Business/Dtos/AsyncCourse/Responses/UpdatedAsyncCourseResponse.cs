using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.AsyncCourse.Responses
{
    public class UpdatedAsyncCourseResponse
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid CourseDetailId { get; set; }
        public DateTime EstimatedTime { get; set; }
        public string ProducingCompany { get; set; }
    }
}

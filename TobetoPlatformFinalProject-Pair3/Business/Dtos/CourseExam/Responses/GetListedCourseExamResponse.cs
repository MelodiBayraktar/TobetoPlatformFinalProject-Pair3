using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.CourseExam.Responses
{
    public class GetListedCourseExamResponse
    {
        public Guid? Id { get; set; }
        public Guid? StudentId { get; set; }
        public string? Name { get; set; }
        public string? Time { get; set; }
        public bool? Status { get; set; }
        public string? Description { get; set; }
        public string? ExamUrl { get; set; }
    }
}

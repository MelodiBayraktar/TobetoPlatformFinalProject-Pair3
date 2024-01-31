using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.CourseExam.Requests
{
    public class UpdateCourseExamRequest
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseDetailId { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public string ExamUrl { get; set; }
    }
}

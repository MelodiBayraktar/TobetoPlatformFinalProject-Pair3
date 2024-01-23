using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.LiveCourse.Responses
{
    public class GetLiveCourseResponse
    {
        public Guid Id { get; set;}
        public Guid CourseId { get; set;}
        public Guid CourseDetailId { get; set; }
        public string LiveCourseTitle { get; set; }
        public string LiveCourseCategoryName { get; set; }
        public int LiveCourseContentCount { get; set; }
        public bool LiveCourseIsFavorited { get; set; }
        public bool LiveCourseIsLiked { get; set; }
        public  DateTime LiveCourseStartDate { get; set; }
        public  DateTime LiveCourseEndDate { get; set; }
        public  DateTime LiveCourseSpentTime { get; set; }
    }
}

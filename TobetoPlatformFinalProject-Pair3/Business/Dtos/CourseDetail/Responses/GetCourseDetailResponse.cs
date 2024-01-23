using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.CourseDetail.Responses
{
    public class GetCourseDetailResponse
    {
        public Guid? Id { get; set; }
        public Guid? CourseCategoryId { get; set; }
        public string? CourseCategoryName { get; set; }
        public string? Name { get; set; }
        public bool? IsLiked { get; set; }
        public bool? IsFavorited { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? SpentTime { get; set; }
        public int? ContentCount { get; set; }
    }
}

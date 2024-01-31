namespace Business.Dtos.AsyncCourse.Responses;

public class GetListedAsyncCourseResponse
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid CourseDetailId { get; set; }
    public string AsyncCourseName { get; set; }
    public string AsyncCourseCategoryName { get; set; }
    public int AsyncCourseContentCount { get; set; }
    public DateTime AsyncCourseStartDate { get; set; }
    public DateTime AsyncCourseEndDate { get; set; }
    public DateTime AsyncCourseSpentTime { get; set; }

    public DateTime EstimatedTime { get; set; }
    public bool AsyncCourseIsFavorited { get; set; }
    public bool AsyncCourseIsLiked { get; set; }

    public string ProducingCompany { get; set; }
}
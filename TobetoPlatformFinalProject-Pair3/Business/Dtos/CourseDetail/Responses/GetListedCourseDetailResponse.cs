namespace Business.Dtos.CourseDetail.Responses;

public class GetListedCourseDetailResponse
{
    public Guid? Id { get; set; }
    public string? CourseCategoryName { get; set; }
    public string? Name { get; set; }
    public bool? IsLiked { get; set; }
    public bool? IsFavorited { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? SpentTime { get; set; }
    public int? ContentCount { get; set; }
}
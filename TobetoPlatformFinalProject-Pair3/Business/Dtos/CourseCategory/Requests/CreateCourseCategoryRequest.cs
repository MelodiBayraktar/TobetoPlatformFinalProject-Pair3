namespace Business.Dtos.CourseCategory.Requests;

public class CreateCourseCategoryRequest
{
    public string? Name { get; set; }
    public Guid? CourseCategoryId { get; set; } 
}
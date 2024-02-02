using Core.Entities.Concretes;

namespace Business.Dtos.Course.Requests;

public class CreateCourseRequest
{
    public string ImageUrl { get; set; }
    public string Title { get; set; }
}
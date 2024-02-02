﻿namespace Business.Dtos.Course.Responses;

public class GetListedCourseResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public DateTime CreatedDate { get; set; }
}

﻿namespace Business.Dtos.AsyncLessonsDetail.Responses;

public class GetListedAsyncLessonsDetailResponse
{
    public Guid Id { get; set; }
    public Guid AsyncLessonsOfContentId { get; set; }
    public bool IsLiked { get; set; }
    public string Category { get; set; }
    public string Language { get; set; }
    public string SubType { get; set; }
    public string Description { get; set; }
    public string ProducingCompany { get; set; }
    public string AsyncLessonsOfContentName { get; set; }
    public int AsyncLessonsOfContentDuration { get; set; }
}

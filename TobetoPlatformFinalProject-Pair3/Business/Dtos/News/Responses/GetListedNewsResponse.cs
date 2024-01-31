﻿namespace Business.Dtos.News.Responses;

public class GetListedNewsResponse
{
    public Guid Id { get; set; }
    public Guid AnnouncementsNewsCategoryId { get; set; }
    public Guid ProjectId { get; set; }
    public string AnnouncementsNewsCategoryName { get; set; }
    public string ProjectName { get; set; }
    public string Title { get; set; }
    public string NewsContent { get; set; }
}

namespace Business.Dtos.Announcement.Requests;

public class CreateAnnouncementRequest
{
    public Guid? AnnouncementsNewsCategoryId { get; set; }
    public Guid? ProjectId { get; set; }
    public string? Title { get; set; }
    public string? AnnouncementContent { get; set; }
}
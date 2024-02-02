namespace Business.Dtos.Announcement.Responses
{
    public class GetListedAnnouncementResponse
    {
        public Guid Id { get; set; }
        public Guid AnnouncementsNewsCategoryId { get; set; }
        public Guid ProjectId { get; set; }
        public string AnnouncementsNewsCategoryName { get; set; }
        public string ProjectName { get; set; }
        public string Title { get; set; }
        public string AnnouncementContent { get; set; }
    }
}
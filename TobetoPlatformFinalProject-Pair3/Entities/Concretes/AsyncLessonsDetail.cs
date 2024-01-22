using Core.Entities.Concretes;

namespace Entities.Concretes;

public class AsyncLessonsDetail : Entity<Guid>
{
    public Guid? AsyncLessonsOfContentId { get; set; }
    public bool? IsLiked { get; set; }
    public string? Category { get; set; }
    public string? Language { get; set; }
    public string? SubType { get; set; }
    public string? Description { get; set; }
    public string? ProducingCompany { get; set; }

    public AsyncLessonsOfContent? AsyncLessonsOfContent { get; set; }
}

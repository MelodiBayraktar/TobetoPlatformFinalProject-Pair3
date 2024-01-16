using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.ToTable("Announcements").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.Title).HasColumnName("Title").IsRequired();
        builder.Property(a => a.AnnouncementContent).HasColumnName("AnnouncementContent").IsRequired();
        builder.Property(b => b.AnnouncementsNewsCategoryId).HasColumnName("AnnouncementsNewsCategoryId").IsRequired();
        builder.Property(b => b.ProjectId).HasColumnName("ProjectId").IsRequired();

        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
        
        builder.HasOne(b => b.Project);
        builder.HasOne(b => b.AnnouncementsNewsCategory);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
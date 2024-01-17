using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class NewsConfiguration : IEntityTypeConfiguration<News>
{
    public void Configure(EntityTypeBuilder<News> builder)
    {
        builder.ToTable("News").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.AnnouncementsNewsCategoryId).HasColumnName("AnnouncementsNewsCategoryIdId").IsRequired();
        builder.Property(a => a.ProjectId).HasColumnName("ProjectId").IsRequired();
        builder.Property(a => a.Title).HasColumnName("Title").IsRequired();
        builder.Property(a => a.NewsContent).HasColumnName("NewsContent").IsRequired();
        
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(b => b.Project)
            .WithMany(n => n.News)
            .HasForeignKey(b => b.ProjectId);


        builder.HasOne(b => b.AnnouncementsNewsCategory)
            .WithMany(n => n.News)
            .HasForeignKey(b => b.AnnouncementsNewsCategoryId);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
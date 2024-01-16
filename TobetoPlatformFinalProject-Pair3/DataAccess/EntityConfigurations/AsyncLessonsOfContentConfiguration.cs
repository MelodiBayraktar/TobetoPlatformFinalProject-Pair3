using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class AsyncLessonsOfContentConfiguration : IEntityTypeConfiguration<AsyncLessonsOfContent>
{
    public void Configure(EntityTypeBuilder<AsyncLessonsOfContent> builder)
    {
        builder.ToTable("AsyncLessonsOfContents").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.AsyncContentId).HasColumnName("AsyncContentId").IsRequired();
        builder.Property(a => a.Type).HasColumnName("Type").IsRequired();
        builder.Property(a => a.Name).HasColumnName("Name").IsRequired();
        builder.Property(a => a.Duration).HasColumnName("Duration").IsRequired();
        builder.Property(a => a.IsCompleted).HasColumnName("IsCompleted").IsRequired();
        builder.Property(a => a.ImageUrl).HasColumnName("ImageUrl").IsRequired();
        builder.Property(a => a.VideoUrl).HasColumnName("VideoUrl").IsRequired();
        
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
        
        builder.HasOne(b => b.AsyncContent);
        builder.HasMany(b => b.AsyncLessonsDetails);
        
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
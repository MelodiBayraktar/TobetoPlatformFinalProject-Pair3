using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class AsyncContentConfiguration : IEntityTypeConfiguration<AsyncContent>
{
    public void Configure(EntityTypeBuilder<AsyncContent> builder)
    {
        builder.ToTable("AsyncContents").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.AsyncCourseId).HasColumnName("AsyncCourseId").IsRequired();
        builder.Property(a => a.Name ).HasColumnName("Name").IsRequired();
        
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
        
        builder.HasMany(b => b.AsyncLessonsOfContents);
        builder.HasOne(b => b.AsyncCourse);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
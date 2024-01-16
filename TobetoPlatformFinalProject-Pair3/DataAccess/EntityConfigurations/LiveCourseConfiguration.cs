using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class LiveCourseConfiguration : IEntityTypeConfiguration<LiveCourse>
{
    public void Configure(EntityTypeBuilder<LiveCourse> builder)
    {
        builder.ToTable("LiveCourses").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.CourseId).HasColumnName("CourseId").IsRequired();
        builder.Property(a => a.CourseDetailId).HasColumnName("CourseDetailId").IsRequired();
        
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
        
        builder.HasOne(b => b.Course);
        builder.HasOne(b => b.CourseDetail);
        builder.HasMany(b => b.LiveContents);
        
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
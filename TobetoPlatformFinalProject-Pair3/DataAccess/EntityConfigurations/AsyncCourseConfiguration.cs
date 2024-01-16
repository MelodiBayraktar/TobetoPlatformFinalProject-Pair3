using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class AsyncCourseConfiguration : IEntityTypeConfiguration<AsyncCourse>
{
    public void Configure(EntityTypeBuilder<AsyncCourse> builder)
    {
        builder.ToTable("AsyncCourses").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.CourseId).HasColumnName("CourseId").IsRequired();
        builder.Property(a => a.CourseDetailId).HasColumnName("CourseDetailId").IsRequired();
        builder.Property(a => a.EstimatedTime).HasColumnName("EstimatedTime").IsRequired();
        builder.Property(a => a.ProducingCompany).HasColumnName("ProducingCompany").IsRequired();
        
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
        
        builder.HasMany(b => b.AsyncContents);
        builder.HasOne(b => b.Course);
        builder.HasOne(b => b.CourseDetail);
        
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
using Entities;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class CourseDetailConfiguration : IEntityTypeConfiguration<CourseDetail>
{
    public void Configure(EntityTypeBuilder<CourseDetail> builder)
    {
        builder.ToTable("CourseDetails").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.CourseCategoryId).HasColumnName("CourseCategoryId").IsRequired();
        builder.Property(a => a.Name).HasColumnName("Name").IsRequired();
        builder.Property(a => a.IsFavorited).HasColumnName("IsFavorited").IsRequired();
        builder.Property(a => a.IsLiked).HasColumnName("IsLiked").IsRequired();
        builder.Property(a => a.StartDate).HasColumnName("StartDate").IsRequired();
        builder.Property(a => a.EndDate).HasColumnName("EndDate").IsRequired();
        builder.Property(a => a.SpentTime).HasColumnName("SpentTime").IsRequired();
        builder.Property(a => a.ContentCount).HasColumnName("ContentCount").IsRequired();
        
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(b => b.CourseCategory)
            .WithMany(cd => cd.CourseDetails)
            .HasForeignKey(b => b.CourseCategoryId);


        builder.HasMany(b => b.AsyncCourses)
            .WithOne(cd => cd.CourseDetail)
            .HasForeignKey(cd => cd.CourseDetailId);


        builder.HasMany(b => b.LiveCourses)
            .WithOne(cd => cd.CourseDetail)
            .HasForeignKey(cd => cd.CourseDetailId);


        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
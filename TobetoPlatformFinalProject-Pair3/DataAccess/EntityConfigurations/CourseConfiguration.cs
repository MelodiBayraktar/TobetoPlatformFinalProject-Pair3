using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Categories").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(a => a.ImageUrl).HasColumnName("ImageUrl").IsRequired();
        builder.Property(a => a.Title).HasColumnName("Title").IsRequired();

        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(b => b.User)
            .WithMany(c => c.Courses)
            .HasForeignKey(b => b.UserId);


        builder.HasMany(b => b.AsyncCourses)
            .WithOne(c => c.Course)
            .HasForeignKey(c => c.CourseId);


        builder.HasMany(b => b.LiveCourses)
            .WithOne(c => c.Course)
            .HasForeignKey(c => c.CourseId);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
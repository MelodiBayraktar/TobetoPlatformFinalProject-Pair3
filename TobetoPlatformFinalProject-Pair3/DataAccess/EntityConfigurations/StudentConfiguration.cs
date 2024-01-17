using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.UserId).HasColumnName("UserId").IsRequired();
        
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(b => b.User)
            .WithMany(s => s.Students)
            .HasForeignKey(b => b.UserId);


        builder.HasMany(b => b.Surveys)
            .WithOne(s => s.Student)
            .HasForeignKey(s => s.StudentId);


        builder.HasMany(b => b.CourseExams)
            .WithOne(s => s.Student)
            .HasForeignKey(s => s.StudentId);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
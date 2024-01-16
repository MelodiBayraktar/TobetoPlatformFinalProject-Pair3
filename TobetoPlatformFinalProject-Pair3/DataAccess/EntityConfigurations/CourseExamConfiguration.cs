using Entities;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class CourseExamConfiguration : IEntityTypeConfiguration<CourseExam>
{
    public void Configure(EntityTypeBuilder<CourseExam> builder)
    {
        builder.ToTable("CourseExams").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.StudentId).HasColumnName("StudentId").IsRequired();
        builder.Property(a => a.Name).HasColumnName("Name").IsRequired();
        builder.Property(a => a.Description).HasColumnName("Description").IsRequired();
        builder.Property(a => a.Time).HasColumnName("Time").IsRequired();
        builder.Property(a => a.Status).HasColumnName("Status").IsRequired();
        builder.Property(a => a.ExamUrl).HasColumnName("ExamUrl").IsRequired();
        
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
        
        builder.HasOne(b => b.Student);
        
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
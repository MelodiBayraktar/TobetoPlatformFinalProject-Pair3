using Entities;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class EducationConfiguration : IEntityTypeConfiguration<Education>
{
    public void Configure(EntityTypeBuilder<Education> builder)
    {
        builder.ToTable("Educations").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(a => a.EducationLevel).HasColumnName("EducationLevel").IsRequired();
        builder.Property(a => a.University).HasColumnName("University").IsRequired();
        builder.Property(a => a.Department).HasColumnName("Department").IsRequired();
        builder.Property(a => a.StartDate).HasColumnName("StartDate").IsRequired();
        builder.Property(a => a.GraduationYear).HasColumnName("GraduationYear").IsRequired();
        
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
        
        builder.HasOne(b => b.User);
        
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
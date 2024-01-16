using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class LiveContentConfiguration : IEntityTypeConfiguration<LiveContent>
{
    public void Configure(EntityTypeBuilder<LiveContent> builder)
    {
        builder.ToTable("LiveContents").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.LiveCourseId).HasColumnName("LiveCourseId").IsRequired();
        builder.Property(a => a.Name).HasColumnName("Name").IsRequired();
        builder.Property(a => a.Type).HasColumnName("Type").IsRequired();
        builder.Property(a => a.IsContinue).HasColumnName("IsContinue").IsRequired();
        
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
        
        builder.HasOne(b => b.LiveCourse);
        builder.HasMany(b => b.Sessions);
        
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.Name).HasColumnName("Name").IsRequired();

        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(b => b.Applications)
            .WithOne(p => p.Project)
            .HasForeignKey(p => p.ProjectId);
            
        builder.HasMany(b => b.News)
            .WithOne(p => p.Project)
            .HasForeignKey(p => p.ProjectId);


        builder.HasMany(b => b.Announcements)
            .WithOne(p => p.Project)
            .HasForeignKey(p => p.ProjectId);


        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
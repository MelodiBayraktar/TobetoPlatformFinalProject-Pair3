using Entities;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.ToTable("Experiences").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(a => a.OrganizationName).HasColumnName("OrganizationName").IsRequired();
        builder.Property(a => a.Position).HasColumnName("Position").IsRequired();
        builder.Property(a => a.Sector).HasColumnName("Sector").IsRequired();
        builder.Property(a => a.City).HasColumnName("City").IsRequired();
        builder.Property(a => a.StartDate).HasColumnName("StartDate").IsRequired();
        builder.Property(a => a.EndDate).HasColumnName("EndDate").IsRequired();
        builder.Property(a => a.Description).HasColumnName("Description").IsRequired();
        
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(b => b.User)
            .WithMany(e => e.Experiences)
            .HasForeignKey(b => b.UserId);


        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
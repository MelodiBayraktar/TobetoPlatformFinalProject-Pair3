using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class PersonalInfoConfiguration : IEntityTypeConfiguration<PersonalInfo>
{
    public void Configure(EntityTypeBuilder<PersonalInfo> builder)
    {
        builder.ToTable("PersonalInfos").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(a => a.About).HasColumnName("About").IsRequired();
        builder.Property(a => a.ProfileImageUrl).HasColumnName("ProfileImageUrl").IsRequired();
        builder.Property(a => a.BirthDate).HasColumnName("BirthDate").IsRequired();
        builder.Property(a => a.Address).HasColumnName("Address").IsRequired();
        builder.Property(a => a.District).HasColumnName("District").IsRequired();
        builder.Property(a => a.City).HasColumnName("City").IsRequired();
        builder.Property(a => a.Country).HasColumnName("Country").IsRequired();
        builder.Property(a => a.NationalIdentity).HasColumnName("NationalIdentity").IsRequired();
        
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(b => b.User)
            .WithMany(pi => pi.PersonalInfos)
            .HasForeignKey(b => b.UserId);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
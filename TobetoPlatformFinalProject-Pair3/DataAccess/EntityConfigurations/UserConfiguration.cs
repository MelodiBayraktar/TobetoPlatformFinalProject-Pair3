using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.FirstName).HasColumnName("FirstName").IsRequired();
            builder.Property(b => b.LastName).HasColumnName("LastName").IsRequired();
            builder.Property(b => b.Email).HasColumnName("Email").IsRequired();
            builder.Property(b => b.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
            builder.Property(b => b.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
            builder.Property(b => b.PasswordHash).HasColumnName("PasswordHash").IsRequired();
            builder.Property(b => b.Status).HasColumnName("Status");

            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

            //builder.HasMany(s => s.Courses);
            //builder.HasMany(s => s.Students);
            //builder.HasMany(s => s.Instructors);
            //builder.HasMany(s => s.Settings);
            //builder.HasMany(s => s.PasswordResets);
            //builder.HasMany(s => s.PersonalInfos);
            //builder.HasMany(s => s.Experiences);
            //builder.HasMany(s => s.SocialAccounts);
            //builder.HasMany(s => s.Certificates);
            //builder.HasMany(s => s.Educations);
            //builder.HasMany(s => s.ForeignLanguages);
            //builder.HasMany(s => s.Abilities);
            //builder.HasMany(s => s.UserOperationClaims);

            builder.HasMany(u => u.Abilities)
            .WithOne(ab => ab.User)
            .HasForeignKey(ab => ab.UserId);

            builder.HasMany(c => c.Courses)
            .WithOne(ab => ab.User)
            .HasForeignKey(ab => ab.UserId);

            builder.HasMany(s => s.Students)
            .WithOne(ab => ab.User)
            .HasForeignKey(ab => ab.UserId);

            builder.HasMany(i => i.Instructors)
            .WithOne(ab => ab.User)
            .HasForeignKey(ab => ab.UserId);

            builder.HasMany(s => s.Settings)
            .WithOne(ab => ab.User)
            .HasForeignKey(ab => ab.UserId);

            builder.HasMany(ps => ps.PasswordResets)
            .WithOne(ab => ab.User)
            .HasForeignKey(ab => ab.UserId);

            builder.HasMany(ps => ps.PersonalInfos)
            .WithOne(ab => ab.User)
            .HasForeignKey(ab => ab.UserId);

            builder.HasMany(e => e.Experiences)
            .WithOne(ab => ab.User)
            .HasForeignKey(ab => ab.UserId);

            builder.HasMany(sa => sa.SocialAccounts)
            .WithOne(ab => ab.User)
            .HasForeignKey(ab => ab.UserId);

            builder.HasMany(c => c.Certificates)
            .WithOne(ab => ab.User)
            .HasForeignKey(ab => ab.UserId);

            builder.HasMany(e => e.Educations)
            .WithOne(ab => ab.User)
            .HasForeignKey(ab => ab.UserId);

            builder.HasMany(e => e.ForeignLanguages)
            .WithOne(ab => ab.User)
            .HasForeignKey(ab => ab.UserId);

            builder.HasMany(uoc => uoc.UserOperationClaims)
            .WithOne(ab => ab.User)
            .HasForeignKey(ab => ab.UserId);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
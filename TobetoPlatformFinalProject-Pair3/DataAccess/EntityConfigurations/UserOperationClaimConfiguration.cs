using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {

            builder.ToTable("UserOperationClaims").HasKey(u => u.Id);
            
            builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
            builder.Property(u => u.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(u => u.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
            
            builder.HasOne(uop => uop.User);
            builder.HasOne(uop => uop.OperationClaim);

            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);
            

        }
    }
}

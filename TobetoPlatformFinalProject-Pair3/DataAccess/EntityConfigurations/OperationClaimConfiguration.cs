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
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("OperationClaim").HasKey(op => op.Id);

            builder.Property(op => op.Id).HasColumnName("Id").IsRequired();
            builder.Property(op => op.Name).HasColumnName("Name").IsRequired();

            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
            
            builder.HasMany(op => op.Users);

            builder.HasQueryFilter(op => !op.DeletedDate.HasValue);
            
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Furniture.Data.Entities;
using Furniture.Data.EF.Extensions;

namespace Furniture.Data.Configurations
{
    public class OrderDetailConfiguration : DbEntityConfiguration<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> entity)
        {
            entity.Property(od => od.CreatedBy).IsUnicode(false)
                                               .HasMaxLength(128)
                                               .IsRequired();

            entity.Property(od => od.UpdatedBy).IsUnicode(false)
                                               .HasMaxLength(128);
        }
    }
}
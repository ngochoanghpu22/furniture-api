using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Furniture.Data.Entities;
using Furniture.Data.EF.Extensions;

namespace Furniture.Data.Configurations
{
    public class OrderConfiguration : DbEntityConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.HasMany(o => o.OrderDetails)
                  .WithOne(o => o.Order)
                  .HasForeignKey(u => u.OrderId);

            entity.Property(o => o.Status).IsUnicode(false)
                                          .HasMaxLength(32);

            entity.Property(o => o.CreatedBy).IsUnicode(false)
                                             .HasMaxLength(128)
                                             .IsRequired();

            entity.Property(o => o.UpdatedBy).IsUnicode(false)
                                             .HasMaxLength(128);
        }
    }
}
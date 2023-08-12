using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Furniture.Data.Entities;
using Furniture.Data.EF.Extensions;

namespace Furniture.Data.Configurations
{
    public class ProductConfiguration : DbEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasIndex(p => p.Name).IsUnique();

            entity.Property(p => p.Name).IsUnicode(false)
                                        .HasMaxLength(128)
                                        .IsRequired();

            entity.Property(p => p.Image).IsUnicode(false)
                                         .HasMaxLength(256)
                                         .IsRequired();

            entity.Property(p => p.Description).IsUnicode(false);

            entity.Property(p => p.Status).IsUnicode(false)
                                          .HasMaxLength(32);

            entity.Property(p => p.CreatedBy).IsUnicode(false)
                                             .HasMaxLength(128)
                                             .IsRequired();

            entity.Property(p => p.UpdatedBy).IsUnicode(false)
                                             .HasMaxLength(128);
        }
    }
}

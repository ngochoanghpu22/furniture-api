using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Furniture.Data.Entities;
using Furniture.Data.EF.Extensions;

namespace Furniture.Data.Configurations
{
    public class CategoryConfiguration : DbEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasMany(c => c.Products)
                  .WithOne(c => c.Category)
                  .HasForeignKey(c => c.CategoryId);

            entity.HasIndex(c => c.Name).IsUnique();

            entity.Property(c => c.Name).IsUnicode(false)
                                        .HasMaxLength(128)
                                        .IsRequired();

            entity.Property(c => c.Image).IsUnicode(false)
                                         .HasMaxLength(256)
                                         .IsRequired();

            entity.Property(c => c.Status).IsUnicode(false)
                                          .HasMaxLength(32);

            entity.Property(c => c.CreatedBy).IsUnicode(false)
                                             .HasMaxLength(128)
                                             .IsRequired();

            entity.Property(c => c.UpdatedBy).IsUnicode(false)
                                             .HasMaxLength(128);
        }
    }
}
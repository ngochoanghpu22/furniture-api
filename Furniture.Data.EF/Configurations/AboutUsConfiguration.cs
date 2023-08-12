using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Furniture.Data.Entities;
using Furniture.Data.EF.Extensions;

namespace Furniture.Data.Configurations
{
    public class AboutUsConfiguration : DbEntityConfiguration<AboutUs>
    {
        public override void Configure(EntityTypeBuilder<AboutUs> entity)
        {
            entity.Property(a => a.Name).IsUnicode(false)
                                        .HasMaxLength(64)
                                        .IsRequired();

            entity.Property(a => a.Phone).IsUnicode(false)
                                         .HasMaxLength(32)
                                         .IsRequired();

            entity.Property(a => a.Address).IsUnicode(false)
                                           .HasMaxLength(512)
                                           .IsRequired();

            entity.Property(a => a.Logo).IsUnicode(false)
                                        .HasMaxLength(256)
                                        .IsRequired();

            entity.Property(a => a.Description).IsUnicode(false);

            entity.Property(a => a.CreatedBy).IsUnicode(false)
                                             .HasMaxLength(128)
                                             .IsRequired();

            entity.Property(a => a.UpdatedBy).IsUnicode(false)
                                             .HasMaxLength(128);
        }
    }
}

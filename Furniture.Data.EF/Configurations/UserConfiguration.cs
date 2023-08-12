using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Furniture.Data.Entities;
using Furniture.Data.EF.Extensions;

namespace Furniture.Data.Configurations
{
    public class UserConfiguration : DbEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasMany(u => u.Orders)
                  .WithOne(u => u.User)
                  .HasForeignKey(u => u.UserId);

            entity.HasIndex(u => u.Name);

            entity.Property(u => u.Name).IsUnicode(false)
                                        .HasMaxLength(128)
                                        .IsRequired();

            entity.HasIndex(u => u.Email).IsUnique();

            entity.Property(u => u.Email).IsUnicode(false)
                                         .HasMaxLength(64)
                                         .IsRequired();



            entity.Property(u => u.Role).IsUnicode(false)
                                        .HasMaxLength(32)
                                        .IsRequired();

            entity.Property(u => u.Phone).IsUnicode(false)
                                         .HasMaxLength(32)
                                         .IsRequired();

            entity.Property(u => u.Avatar).IsUnicode(false)
                                          .HasMaxLength(128);

            entity.Property(u => u.Password).IsUnicode(false)
                                            .HasMaxLength(512)
                                            .IsRequired();

            entity.Property(u => u.Status).IsUnicode(false)
                                          .HasMaxLength(32);


            entity.Property(u => u.CreatedBy).IsUnicode(false)
                                             .HasMaxLength(128)
                                             .IsRequired();

            entity.Property(u => u.UpdatedBy).IsUnicode(false)
                                             .HasMaxLength(128);
        }
    }
}
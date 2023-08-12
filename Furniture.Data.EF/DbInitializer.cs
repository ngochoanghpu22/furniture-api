using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Furniture.Data.Entities;
using Furniture.Utilities.Constants;
using Furniture.Utilities.Helpers;
using static Furniture.Utilities.Enums;

namespace Furniture.Data
{
    public class DbInitializer
    {
        private readonly FurnitureContext _context;
        public DbInitializer(FurnitureContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            await SeedUsers();
        }

        public async Task SeedUsers()
        {
            if (!_context.Users.Any())
            {
                string passwordHash = Cryptography.EncryptString("123456");

                _context.Users.AddRange(new List<User>()
                {
                    new User {
                        Name = "Admin",
                        Email = "admin@gmail.com",
                        Role = RoleConstants.AdminRoleName,
                        Phone = "0123456789",
                        Avatar = "assets/images/users/no-avatar.png",
                        Password = passwordHash,
                        Status = UserStatus.Active.ToString(),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "System"
                    },
                    new User {
                        Name = "Martin",
                        Email = "martin.h@vanthiel.com",
                        Role = RoleConstants.AdminRoleName,
                        Phone = "0123456789",
                        Avatar = "assets/images/users/no-avatar.png",
                        Password = passwordHash,
                        Status = UserStatus.Active.ToString(),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "System"
                    },
                    new User {
                        Name = "Renel",
                        Email = "renel.c@vanthiel.com",
                        Role = RoleConstants.AdminRoleName,
                        Phone = "0123456789",
                        Avatar = "assets/images/users/no-avatar.png",
                        Password = passwordHash,
                        Status = UserStatus.Active.ToString(),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "System"
                    },
                    new User {
                        Name = "Quirine",
                        Email = "quirine@vanthiel.com",
                        Role = RoleConstants.UserRoleName,
                        Phone = "0123456789",
                        Avatar = "assets/images/users/no-avatar.png",
                        Password = passwordHash,
                        Status = UserStatus.Active.ToString(),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "System"
                    },
                    new User {
                        Name = "Quynh",
                        Email = "phuongquynh.n@vanthiel.com",
                        Role = RoleConstants.UserRoleName,
                        Phone = "0123456789",
                        Avatar = "assets/images/users/no-avatar.png",
                        Password = passwordHash,
                        Status = UserStatus.Active.ToString(),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "System"
                    },
                    new User {
                        Name = "User",
                        Email = "user@gmail.com",
                        Role = RoleConstants.UserRoleName,
                        Phone = "0123456789",
                        Avatar = "assets/images/users/no-avatar.png",
                        Password = passwordHash,
                        Status = UserStatus.Active.ToString(),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "System"
                    }
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}
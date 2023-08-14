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

            await SeedProducts();
        }

        private async Task SeedUsers()
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

        private async Task SeedProducts()
        {
            if (!_context.Categories.Any())
            {
                var baseUrl = "https://localhost:5001";

                _context.Categories.AddRange(new List<Category>()
                {
                    new Category
                    {
                        Name = "Sofas",
                        Image = $"{baseUrl}/images/category/sofa.png",
                        Status = CategoryStatus.Active.ToString(),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = CommonConstants.CreatedBySystem,
                        Products = new List<Product>()
                        {
                            new Product
                            {
                                Name = "Leather Modular 1 seater",
                                ThumbnailImage = $"{baseUrl}/images/product/sofa/1.png",
                                OriginalImage = $"{baseUrl}/images/product/sofa/1.png",
                                Price = 13970000,
                                QuantityInStock = 5,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "As a member of the Modular sofa family, this leather Modular collection is wider in size for utmost comfort while bright up elegance and classic to any space. You will immediately feel an all-out relaxation as soon as you sink into it thanks to the thick feather layer on top, but still retaining the shape supported by mousse's excellent elasticity."
                            },
                            new Product
                            {
                                Name = "Leather Modular 2 seater",
                                ThumbnailImage = $"{baseUrl}/images/product/sofa/2.png",
                                OriginalImage = $"{baseUrl}/images/product/sofa/2.png",
                                Price = 27940000 ,
                                QuantityInStock = 2,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "As a member of the Modular sofa family, this leather Modular collection is wider in size for utmost comfort while bright up elegance and classic to any space. You will immediately feel an all-out relaxation as soon as you sink into it thanks to the thick feather layer on top, but still retaining the shape supported by mousse's excellent elasticity."
                            },
                            new Product
                            {
                                Name = "Leather Modular 3 seater",
                                ThumbnailImage = $"{baseUrl}/images/product/sofa/3.png",
                                OriginalImage = $"{baseUrl}/images/product/sofa/3.png",
                                Price = 47410000 ,
                                QuantityInStock = 6,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "As a member of the Modular sofa family, this leather Modular collection is wider in size for utmost comfort while bright up elegance and classic to any space. You will immediately feel an all-out relaxation as soon as you sink into it thanks to the thick feather layer on top, but still retaining the shape supported by mousse's excellent elasticity."
                            },
                            new Product
                            {
                                Name = "Leather Modular L",
                                ThumbnailImage = $"{baseUrl}/images/product/sofa/4.png",
                                OriginalImage = $"{baseUrl}/images/product/sofa/4.png",
                                Price = 53350000 ,
                                QuantityInStock = 10,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "As a member of the Modular sofa family, this leather Modular collection is wider in size for utmost comfort while bright up elegance and classic to any space. You will immediately feel an all-out relaxation as soon as you sink into it thanks to the thick feather layer on top, but still retaining the shape supported by mousse's excellent elasticity."
                            },
                            new Product
                            {
                                Name = "Leather Modular sectional",
                                ThumbnailImage = $"{baseUrl}/images/product/sofa/5.png",
                                OriginalImage = $"{baseUrl}/images/product/sofa/5.png",
                                Price = 111540000 ,
                                QuantityInStock = 10,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "As a member of the Modular sofa family, this leather Modular collection is wider in size for utmost comfort while bright up elegance and classic to any space. You will immediately feel an all-out relaxation as soon as you sink into it thanks to the thick feather layer on top, but still retaining the shape supported by mousse's excellent elasticity."
                            }
                        }
                    },
                    new Category
                    {
                        Name = "Coffee & side tables",
                        Image = $"{baseUrl}/images/category/coffee.png",
                        Status = CategoryStatus.Active.ToString(),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = CommonConstants.CreatedBySystem,
                        Products = new List<Product>()
                        {
                            new Product
                            {
                                Name = "Bold tables",
                                ThumbnailImage = $"{baseUrl}/images/product/coffee/1.png",
                                OriginalImage = $"{baseUrl}/images/product/coffee/1.png",
                                Price = 5400000,
                                QuantityInStock = 12,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Inspired by volumetric designs, the Bold table collection is crafted with a thick tabletop, large-pillar legs turned from solid wood, which will be a unique highlight that captivates you."
                            },
                            new Product
                            {
                                Name = "Noir coffee table",
                                ThumbnailImage = $"{baseUrl}/images/product/coffee/2.png",
                                OriginalImage = $"{baseUrl}/images/product/coffee/2.png",
                                Price = 5000000,
                                QuantityInStock = 10,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "This coffee table has a small but sturdy appearance thanks to its legs made from terrazzo. It has a simple design but is really useful in saving your space, you can even put it next to sofa as a side table."
                            },
                            new Product
                            {
                                Name = "Tera coffee tables",
                                ThumbnailImage = $"{baseUrl}/images/product/coffee/3.png",
                                OriginalImage = $"{baseUrl}/images/product/coffee/3.png",
                                Price = 3500000,
                                QuantityInStock = 3,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "This coffee table has a small but sturdy appearance thanks to its legs made from terrazzo. It has a simple design but is really useful in saving your space, you can even put it next to sofa as a side table."
                            },
                            new Product
                            {
                                Name = "Mun tables",
                                ThumbnailImage = $"{baseUrl}/images/product/coffee/4.png",
                                OriginalImage = $"{baseUrl}/images/product/coffee/4.png",
                                Price = 6500000,
                                QuantityInStock = 13,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Our Mun table collection offers 04 different sizes to help you diversify your using purpose. With a striking design, strong lines, highlighted by legs made from striped wood detailing in oak, the Mun table collection will bring an elegant, warm beauty to any space."
                            },
                            new Product
                            {
                                Name = "Box tables",
                                ThumbnailImage = $"{baseUrl}/images/product/coffee/5.png",
                                OriginalImage = $"{baseUrl}/images/product/coffee/5.png",
                                Price = 5200000,
                                QuantityInStock = 11,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Approaching a volumetric aesthetic, our new Box collection functions as a coffee table and a storage. Contemporary yet lean design comes with cleverly hidden drawers that will suit any space."
                            },
                        }
                    },
                    new Category
                    {
                       Name = "Poufs",
                       Image = $"{baseUrl}/images/category/pouf.png",
                       Status = CategoryStatus.Active.ToString(),
                       CreatedDate = DateTime.UtcNow,
                       CreatedBy = CommonConstants.CreatedBySystem,
                       Products = new List<Product>()
                       {
                           new Product
                            {
                                Name = "Cube pouf",
                                ThumbnailImage = $"{baseUrl}/images/product/pouf/1.png",
                                OriginalImage = $"{baseUrl}/images/product/pouf/1.png",
                                Price = 5600000,
                                QuantityInStock = 5,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = ""
                            },
                           new Product
                            {
                                Name = "Guimauve pouf",
                                ThumbnailImage = $"{baseUrl}/images/product/pouf/2.png",
                                OriginalImage = $"{baseUrl}/images/product/pouf/2.png",
                                Price = 3200000,
                                QuantityInStock = 17,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Less is more” is what we would say when talking about this pouf, as whether you are in need of a side table (maybe with a wooden tray on it), a footrest or a spare seat in the living room, it can be all of the above. Besides, with an upholstery of velvet textiles, the Guimauve offers a soft-like-marshmallow feel and elegance to any room."
                            },
                           new Product
                            {
                                Name = "Modular poufs",
                                ThumbnailImage = $"{baseUrl}/images/product/pouf/3.png",
                                OriginalImage = $"{baseUrl}/images/product/pouf/3.png",
                                Price = 4100000,
                                QuantityInStock = 1,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "This Modular sofa collection offers a variety of sizes to suit any space. Due to its simple yet elegant seam and generous size, this product is suitable for relaxation. In addition, it gives a sense of smoothness and good elasticity thanks to the feather layer on top and excellent mousse."
                            },
                           new Product
                            {
                                Name = "Wave pouf",
                                ThumbnailImage = $"{baseUrl}/images/product/pouf/4.png",
                                OriginalImage = $"{baseUrl}/images/product/pouf/4.png",
                                Price = 5200000,
                                QuantityInStock = 8,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Creating a chic yet elegant living space with solid form and soft curves meld in this Wave sofa. Thanks to its modular elements that can be expanded to suit every individual taste, you have no worries about a small or large room, especially when this couch is your corner space saver. The sofa is available in a wide range of colors and fabrics. You can't stop the Wave from coming, but you can sit on it."
                            },
                           new Product
                            {
                                Name = "Classic pouf",
                                ThumbnailImage = $"{baseUrl}/images/product/pouf/5.png",
                                OriginalImage = $"{baseUrl}/images/product/pouf/5.png",
                                Price = 6300000,
                                QuantityInStock = 5,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = ""
                            },
                            new Product
                            {
                                Name = "Rubi ottoman",
                                ThumbnailImage = $"{baseUrl}/images/product/pouf/6.png",
                                OriginalImage = $"{baseUrl}/images/product/pouf/6.png",
                                Price = 5900000,
                                QuantityInStock = 25,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "The Rubi sofa is a casual seating option featuring an asymmetrical armrest and deep seat which offers just as much in a way of comfort. It’s a practical piece of furniture that can be combined to create larger or smaller sofa to suit any space. The thick sewing lines of this Rubi give it a clear shape looking while remaining its graceful and balanced proportions."
                            },
                            new Product
                            {
                                Name = "Rond stool",
                                ThumbnailImage = $"{baseUrl}/images/product/pouf/7.png",
                                OriginalImage = $"{baseUrl}/images/product/pouf/7.png",
                                Price = 2200000,
                                QuantityInStock = 4,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "More” doesn’t necessarily mean “narrow” when it can be your great space-saver. The ROND stool family now comes with a soft upholstered seat, especially the stackable low and medium stools are the best way out when it comes to surprise guests but you have no chair left to seat."
                            },
                       }
                    },
                    new Category
                    {
                       Name = "Dining tables",
                       Image = $"{baseUrl}/images/category/table.png",
                       Status = CategoryStatus.Active.ToString(),
                       CreatedDate = DateTime.UtcNow,
                       CreatedBy = CommonConstants.CreatedBySystem,
                       Products = new List<Product>()
                       {
                           new Product
                           {
                                Name = "Z-T01 dining table",
                                ThumbnailImage = $"{baseUrl}/images/product/table/1.png",
                                OriginalImage = $"{baseUrl}/images/product/table/1.png",
                                Price = 11800000,
                                QuantityInStock = 54,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "The lines designed in this Z-T01 table model have a flat shape, giving this table a slim feel. However, contrary to its appearance, the table is very sturdy with a capacity of 06 to 08 people sitting whether it is a dining table or a desk."
                            },
                           new Product
                           {
                                Name = "Z-T02 dining tables",
                                ThumbnailImage = $"{baseUrl}/images/product/table/2.png",
                                OriginalImage = $"{baseUrl}/images/product/table/2.png",
                                Price = 7800000,
                                QuantityInStock = 19,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Approaching a minimalist aesthetic, this radius corner dining table is truly a family-friendly design. It comes with 3 choices of size, 2 choices of colors, and a set of leg caps, allowing you to design your own dining table that will blend so fine with your personal space, whether it's a dining room or a workroom."
                            },
                           new Product
                           {
                                Name = "Mun dining table",
                                ThumbnailImage = $"{baseUrl}/images/product/table/3.png",
                                OriginalImage = $"{baseUrl}/images/product/table/3.png",
                                Price = 8800000,
                                QuantityInStock = 20,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Our Mun table collection offers 04 different sizes to help you diversify your using purpose. With a striking design, strong lines, highlighted by legs made from striped wood detailing in oak, the Mun table collection will bring an elegant, warm beauty to any space."
                            },
                       }
                    },
                    new Category
                    {
                        Name = "Chairs",
                       Image = $"{baseUrl}/images/category/chair.png",
                       Status = CategoryStatus.Active.ToString(),
                       CreatedDate = DateTime.UtcNow,
                       CreatedBy = CommonConstants.CreatedBySystem,
                       Products = new List<Product>()
                       {
                           new Product
                           {
                                Name = "Z-C06 chair / Fabric",
                                ThumbnailImage = $"{baseUrl}/images/product/chair/1.png",
                                OriginalImage = $"{baseUrl}/images/product/chair/1.png",
                                Price = 11800000,
                                QuantityInStock = 54,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Focusing on minimalist design yet practical function, the Z-C06 chair is tailored with minimal materials. Fragile as they might seem, they are in fact stable and comfortable due to the curved backrest and seat profile. Comfort and ergonomics are what you can find in our new pieces of furniture, which are ideal for both dining and working from home purpose."
                            },
                           new Product
                           {
                                Name = "Z-C08",
                                ThumbnailImage = $"{baseUrl}/images/product/chair/2.png",
                                OriginalImage = $"{baseUrl}/images/product/chair/2.png",
                                Price = 11800000,
                                QuantityInStock = 54,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Focusing on minimalist design yet practical function, the Z-C06 chair is tailored with minimal materials. Fragile as they might seem, they are in fact stable and comfortable due to the curved backrest and seat profile. Comfort and ergonomics are what you can find in our new pieces of furniture, which are ideal for both dining and working from home purpose."
                            },
                           new Product
                           {
                                Name = "Z-C00",
                                ThumbnailImage = $"{baseUrl}/images/product/chair/3.png",
                                OriginalImage = $"{baseUrl}/images/product/chair/3.png",
                                Price = 11800000,
                                QuantityInStock = 54,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Focusing on minimalist design yet practical function, the Z-C06 chair is tailored with minimal materials. Fragile as they might seem, they are in fact stable and comfortable due to the curved backrest and seat profile. Comfort and ergonomics are what you can find in our new pieces of furniture, which are ideal for both dining and working from home purpose."
                            },
                           new Product
                           {
                                Name = "Z-C05",
                                ThumbnailImage = $"{baseUrl}/images/product/chair/4.png",
                                OriginalImage = $"{baseUrl}/images/product/chair/4.png",
                                Price = 11800000,
                                QuantityInStock = 54,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Focusing on minimalist design yet practical function, the Z-C06 chair is tailored with minimal materials. Fragile as they might seem, they are in fact stable and comfortable due to the curved backrest and seat profile. Comfort and ergonomics are what you can find in our new pieces of furniture, which are ideal for both dining and working from home purpose."
                            },
                           new Product
                           {
                                Name = "Z-C06",
                                ThumbnailImage = $"{baseUrl}/images/product/chair/5.png",
                                OriginalImage = $"{baseUrl}/images/product/chair/5.png",
                                Price = 11800000,
                                QuantityInStock = 54,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Focusing on minimalist design yet practical function, the Z-C06 chair is tailored with minimal materials. Fragile as they might seem, they are in fact stable and comfortable due to the curved backrest and seat profile. Comfort and ergonomics are what you can find in our new pieces of furniture, which are ideal for both dining and working from home purpose."
                            },
                           new Product
                           {
                                Name = "Z-C09",
                                ThumbnailImage = $"{baseUrl}/images/product/chair/6.png",
                                OriginalImage = $"{baseUrl}/images/product/chair/6.png",
                                Price = 11800000,
                                QuantityInStock = 54,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Focusing on minimalist design yet practical function, the Z-C06 chair is tailored with minimal materials. Fragile as they might seem, they are in fact stable and comfortable due to the curved backrest and seat profile. Comfort and ergonomics are what you can find in our new pieces of furniture, which are ideal for both dining and working from home purpose."
                            },
                           new Product
                           {
                                Name = "Z-C19",
                                ThumbnailImage = $"{baseUrl}/images/product/chair/7.png",
                                OriginalImage = $"{baseUrl}/images/product/chair/7.png",
                                Price = 11800000,
                                QuantityInStock = 54,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Focusing on minimalist design yet practical function, the Z-C06 chair is tailored with minimal materials. Fragile as they might seem, they are in fact stable and comfortable due to the curved backrest and seat profile. Comfort and ergonomics are what you can find in our new pieces of furniture, which are ideal for both dining and working from home purpose."
                            },
                           new Product
                           {
                                Name = "B-C19",
                                ThumbnailImage = $"{baseUrl}/images/product/chair/8.png",
                                OriginalImage = $"{baseUrl}/images/product/chair/8.png",
                                Price = 11800000,
                                QuantityInStock = 54,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Focusing on minimalist design yet practical function, the Z-C06 chair is tailored with minimal materials. Fragile as they might seem, they are in fact stable and comfortable due to the curved backrest and seat profile. Comfort and ergonomics are what you can find in our new pieces of furniture, which are ideal for both dining and working from home purpose."
                            },
                           new Product
                           {
                                Name = "B-C29",
                                ThumbnailImage = $"{baseUrl}/images/product/chair/9.png",
                                OriginalImage = $"{baseUrl}/images/product/chair/9.png",
                                Price = 11800000,
                                QuantityInStock = 54,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Focusing on minimalist design yet practical function, the Z-C06 chair is tailored with minimal materials. Fragile as they might seem, they are in fact stable and comfortable due to the curved backrest and seat profile. Comfort and ergonomics are what you can find in our new pieces of furniture, which are ideal for both dining and working from home purpose."
                            },
                       }
                    },
                    new Category 
                    {
                       Name = "ArmChairs",
                       Image = $"{baseUrl}/images/category/armchair.png",
                       Status = CategoryStatus.Active.ToString(),
                       CreatedDate = DateTime.UtcNow,
                       CreatedBy = CommonConstants.CreatedBySystem,
                       Products = new List<Product>()
                       {
                           new Product
                           {
                                Name = "Z-A01 armchair",
                                ThumbnailImage = $"{baseUrl}/images/product/armchair/1.png",
                                OriginalImage = $"{baseUrl}/images/product/armchair/1.png",
                                Price = 11800000,
                                QuantityInStock = 54,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "There's nothing more relaxing than an armchair that makes you feel so relaxed from the moment you sit down and you don’t want to stand up. This Z-A01 armchair has a profile with a headrest that is slightly curved inwards to hug your head and neck; a backrest that reclines gradually, along with wooden armrests, is sure to bring a sense of comfort that you cannot deny."
                            },
                           new Product
                           {
                                Name = "Z-A02 armchair",
                                ThumbnailImage = $"{baseUrl}/images/product/armchair/2.png",
                                OriginalImage = $"{baseUrl}/images/product/armchair/2.png",
                                Price = 11800000,
                                QuantityInStock = 5,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "There's nothing more relaxing than an armchair that makes you feel so relaxed from the moment you sit down and you don’t want to stand up. This Z-A01 armchair has a profile with a headrest that is slightly curved inwards to hug your head and neck; a backrest that reclines gradually, along with wooden armrests, is sure to bring a sense of comfort that you cannot deny."
                            },
                           new Product
                           {
                                Name = "Z-A03 armchair",
                                ThumbnailImage = $"{baseUrl}/images/product/armchair/3.png",
                                OriginalImage = $"{baseUrl}/images/product/armchair/3.png",
                                Price = 11800000,
                                QuantityInStock = 5,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "There's nothing more relaxing than an armchair that makes you feel so relaxed from the moment you sit down and you don’t want to stand up. This Z-A01 armchair has a profile with a headrest that is slightly curved inwards to hug your head and neck; a backrest that reclines gradually, along with wooden armrests, is sure to bring a sense of comfort that you cannot deny."
                            },
                           new Product
                           {
                                Name = "Z-A04 armchair",
                                ThumbnailImage = $"{baseUrl}/images/product/armchair/4.png",
                                OriginalImage = $"{baseUrl}/images/product/armchair/4.png",
                                Price = 11800000,
                                QuantityInStock = 5,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "There's nothing more relaxing than an armchair that makes you feel so relaxed from the moment you sit down and you don’t want to stand up. This Z-A01 armchair has a profile with a headrest that is slightly curved inwards to hug your head and neck; a backrest that reclines gradually, along with wooden armrests, is sure to bring a sense of comfort that you cannot deny."
                            },
                           new Product
                           {
                                Name = "Z-A05 armchair",
                                ThumbnailImage = $"{baseUrl}/images/product/armchair/5.png",
                                OriginalImage = $"{baseUrl}/images/product/armchair/5.png",
                                Price = 11800000,
                                QuantityInStock = 5,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "There's nothing more relaxing than an armchair that makes you feel so relaxed from the moment you sit down and you don’t want to stand up. This Z-A01 armchair has a profile with a headrest that is slightly curved inwards to hug your head and neck; a backrest that reclines gradually, along with wooden armrests, is sure to bring a sense of comfort that you cannot deny."
                            },
                           new Product
                           {
                                Name = "Z-A06 armchair",
                                ThumbnailImage = $"{baseUrl}/images/product/armchair/6.png",
                                OriginalImage = $"{baseUrl}/images/product/armchair/6.png",
                                Price = 11800000,
                                QuantityInStock = 5,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "There's nothing more relaxing than an armchair that makes you feel so relaxed from the moment you sit down and you don’t want to stand up. This Z-A01 armchair has a profile with a headrest that is slightly curved inwards to hug your head and neck; a backrest that reclines gradually, along with wooden armrests, is sure to bring a sense of comfort that you cannot deny."
                            },
                       }
                    },
                    new Category
                    {
                       Name = "Bartools",
                       Image = $"{baseUrl}/images/category/bartool.png",
                       Status = CategoryStatus.Active.ToString(),
                       CreatedDate = DateTime.UtcNow,
                       CreatedBy = CommonConstants.CreatedBySystem,
                       Products = new List<Product>()
                       {
                           new Product
                           {
                                Name = "Z-BS01 barstools",
                                ThumbnailImage = $"{baseUrl}/images/product/bartool/1.png",
                                OriginalImage = $"{baseUrl}/images/product/bartool/1.png",
                                Price = 11800000,
                                QuantityInStock = 5,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "A barstool is definitely a must-have piece of furniture if you are a cooking lover and enjoy sharing moments with your beloved ones in your kitchen. Just placing a few barstools in the kitchen island is enough to connect family members and enjoy delightful meals."
                            },
                           new Product
                           {
                                Name = "Z-BS02 barstools",
                                ThumbnailImage = $"{baseUrl}/images/product/bartool/2.png",
                                OriginalImage = $"{baseUrl}/images/product/bartool/2.png",
                                Price = 11800000,
                                QuantityInStock = 5,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "A barstool is definitely a must-have piece of furniture if you are a cooking lover and enjoy sharing moments with your beloved ones in your kitchen. Just placing a few barstools in the kitchen island is enough to connect family members and enjoy delightful meals."
                            },
                           new Product
                           {
                                Name = "Z-BS03 barstools",
                                ThumbnailImage = $"{baseUrl}/images/product/bartool/3.png",
                                OriginalImage = $"{baseUrl}/images/product/bartool/3.png",
                                Price = 11800000,
                                QuantityInStock = 5,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "A barstool is definitely a must-have piece of furniture if you are a cooking lover and enjoy sharing moments with your beloved ones in your kitchen. Just placing a few barstools in the kitchen island is enough to connect family members and enjoy delightful meals."
                            },
                       }
                    },
                    new Category
                    {
                       Name = "Beds",
                       Image = $"{baseUrl}/images/category/bed.png",
                       Status = CategoryStatus.Active.ToString(),
                       CreatedDate = DateTime.UtcNow,
                       CreatedBy = CommonConstants.CreatedBySystem,
                       Products = new List<Product>()
                       {
                           new Product
                           {
                                Name = "Z-B01 bed",
                                ThumbnailImage = $"{baseUrl}/images/product/bed/1.png",
                                OriginalImage = $"{baseUrl}/images/product/bed/1.png",
                                Price = 11800000,
                                QuantityInStock = 5,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Designed with a full foam and down padding frame, the Z-B01 bed will no doubt give you an all-out relaxation that you won't mind spending a whole day tucking under blankets and watching some TV series, or maybe working at home."
                            },
                           new Product
                           {
                                Name = "Z-B02 bed",
                                ThumbnailImage = $"{baseUrl}/images/product/bed/2.png",
                                OriginalImage = $"{baseUrl}/images/product/bed/2.png",
                                Price = 11800000,
                                QuantityInStock = 5,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Designed with a full foam and down padding frame, the Z-B01 bed will no doubt give you an all-out relaxation that you won't mind spending a whole day tucking under blankets and watching some TV series, or maybe working at home."
                            },
                           new Product
                           {
                                Name = "Z-B03 bed",
                                ThumbnailImage = $"{baseUrl}/images/product/bed/3.png",
                                OriginalImage = $"{baseUrl}/images/product/bed/3.png",
                                Price = 11800000,
                                QuantityInStock = 5,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Designed with a full foam and down padding frame, the Z-B01 bed will no doubt give you an all-out relaxation that you won't mind spending a whole day tucking under blankets and watching some TV series, or maybe working at home."
                            },
                           new Product
                           {
                                Name = "Z-B04 bed",
                                ThumbnailImage = $"{baseUrl}/images/product/bed/4.png",
                                OriginalImage = $"{baseUrl}/images/product/bed/4.png",
                                Price = 11800000,
                                QuantityInStock = 5,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Designed with a full foam and down padding frame, the Z-B01 bed will no doubt give you an all-out relaxation that you won't mind spending a whole day tucking under blankets and watching some TV series, or maybe working at home."
                            },
                       }
                    },
                    new Category
                    {
                        Name = "Accessories",
                       Image = $"{baseUrl}/images/category/accessory.png",
                       Status = CategoryStatus.Active.ToString(),
                       CreatedDate = DateTime.UtcNow,
                       CreatedBy = CommonConstants.CreatedBySystem,
                       Products = new List<Product>()
                       {
                           new Product
                           {
                                Name = "Ladd bookshelves",
                                ThumbnailImage = $"{baseUrl}/images/product/accessory/1.png",
                                OriginalImage = $"{baseUrl}/images/product/accessory/1.png",
                                Price = 11800000,
                                QuantityInStock = 5,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Small in size, wide in knowledge\" is what to describe our Ladd bookcase. With a design that simulates stairs, the Ladd bookcase offers a visual performance that makes books seem to float in space; combined with the sturdy stainless steel construction, it allows you to store all your favorite books without making a mess."
                            },
                           new Product
                           {
                                Name = "Rubik shelf",
                                ThumbnailImage = $"{baseUrl}/images/product/accessory/2.png",
                                OriginalImage = $"{baseUrl}/images/product/accessory/2.png",
                                Price = 11800000,
                                QuantityInStock = 5,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = CommonConstants.CreatedBySystem,
                                Status = ProductStatus.Active.ToString(),
                                Description = "Inspired by the rubik's cube, covered with a black powder coating, the Rubik shelf has a very simple and slender design, with small square blocks divided that looks like miniature picture frames, allowing you to feel free to create your personal decorating ideas or simply storing your favorite items."
                            },
                       }
                    }
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.Application.Dtos
{
    public class OrderDetailDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public List<ProductDto> Products { get; set; }
    }
}

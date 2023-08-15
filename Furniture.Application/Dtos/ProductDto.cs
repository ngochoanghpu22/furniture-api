using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.Application.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ThumbnailImage { get; set; }

        public string OriginalImage { get; set; }

        public decimal Price { get; set; }

        public int QuantityInStock { get; set; }

        public int QuantityOrder{ get; set; }

        public string Description { get; set; }

    }
}

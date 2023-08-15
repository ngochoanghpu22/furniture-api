using System;

namespace Furniture.Application.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string CreatedBy { get; set; }

        public string CreatedDate { get; set; }

        public string Status { get; set; }
    }
}

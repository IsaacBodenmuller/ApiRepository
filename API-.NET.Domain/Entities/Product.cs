using API_.NET.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_.NET.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string? Barcode { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }

        public UnitType UnitType { get; set; }

        public int Stock {  get; set; }
        public int MinStock { get; set; }

        public bool ControlStock { get; set; } = true;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}

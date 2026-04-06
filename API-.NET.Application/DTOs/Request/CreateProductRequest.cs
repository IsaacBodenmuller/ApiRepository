using API_.NET.Domain.Entities;
using API_.NET.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_.NET.Application.DTOs.Request
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string Code { get; set; }
        public string? Barcode { get; set; }

        public int CategoryId { get; set; }

        public int? SupplierId { get; set; }

        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }

        public UnitType UnitType { get; set; }
    }
}

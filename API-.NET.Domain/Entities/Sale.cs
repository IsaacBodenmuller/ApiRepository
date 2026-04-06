using API_.NET.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_.NET.Domain.Entities
{
    public class Sale
    {  
        public int Id { get; set; }

        public DateTime SaleDate { get; set; } = DateTime.Now;

        public decimal GrossValue { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalValue { get; set; }

        public SaleStatus Status { get; set; }

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int CashRegisterId { get; set; }
        public CashRegister CashRegister { get; set; }

        public List<SaleItem> Items { get; set; }
    }
}

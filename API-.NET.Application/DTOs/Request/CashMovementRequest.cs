using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_.NET.Application.DTOs.Request
{
    public class CashMovementRequest
    {
        public decimal Amount { get; set; }
        public string Reason { get; set; }
    }
}

using API_.NET.Domain.Enums;

namespace API_.NET.Domain.Entities
{
    public class CashRegister
    {
        public int Id { get; set; }

        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }

        public decimal OpenValue { get; set; }
        public decimal? CloseValue { get; set; }

        public CashRegisterStatus Status { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public decimal WithdrawAmount { get; set; } = 0;
        public decimal DepositAmount { get; set; } = 0;
    }
}

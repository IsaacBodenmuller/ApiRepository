using API_.NET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_.NET.Application.Interfaces
{
    public interface ICashRegisterRepository
    {
        Task<CashRegister?> GetOpenCashRegister();
        Task<CashRegister> GetById(int id);
        Task Create(CashRegister cashRegister);
        Task Update(CashRegister cashRegister);
    }
}

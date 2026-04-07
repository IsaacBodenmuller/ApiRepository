using API_.NET.Application.Interfaces;
using API_.NET.Domain.Entities;
using API_.NET.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace API_.NET.Infrastructure.Repositories
{
    public class CashRegisterRepository : ICashRegisterRepository
    {
        private readonly AppDbContext _context;
        public CashRegisterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CashRegister?> GetOpenCashRegister()
        {
            return await _context.CashRegisters.FirstOrDefaultAsync(x => x.Status == Domain.Enums.CashRegisterStatus.Open);
        }
        public async Task<CashRegister?> GetById(int id)
        {
            return await _context.CashRegisters.FindAsync(id);
        }
        public async Task Create(CashRegister cashRegister)
        {
            await _context.CashRegisters.AddAsync(cashRegister);
            await _context.SaveChangesAsync();
        }
        public async Task Update(CashRegister cashRegister)
        {
            _context.CashRegisters.Update(cashRegister);
            await _context.SaveChangesAsync();
        }
    }
}

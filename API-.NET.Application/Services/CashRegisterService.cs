using API_.NET.Application.DTOs.Request;
using API_.NET.Application.Interfaces;
using API_.NET.Domain.Entities;
using API_.NET.Domain.Enums;

namespace API_.NET.Application.Services
{
    public class CashRegisterService
    {
        private readonly ICashRegisterRepository _repository;
        public CashRegisterService(ICashRegisterRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Open(OpenCashRegisterRequest request, int userId)
        {
            var openCash = await _repository.GetOpenCashRegister();
            if (openCash != null)
            {
                throw new Exception("Já existe um caixa aberto");
            }

            var cash = new CashRegister
            {
                OpenValue = request.OpenValue,
                OpenDate = DateTime.Now,
                Status = CashRegisterStatus.Open,
                UserId = userId
            };

            await _repository.Create(cash);
            return "Caixa aberto com sucesso";
        }
        public async Task<string> Close(CloseCashRegisterRequest request)
        {
            var cash = await _repository.GetOpenCashRegister();

            if (cash == null)
                throw new Exception("Nenhum caixa aberto");

            cash.CloseValue = request.CloseValue;
            cash.CloseDate = DateTime.Now;
            cash.Status = CashRegisterStatus.Close;

            await _repository.Update(cash);
            return "Caixa fechado com sucesso";
        }
        public async Task<string> Withdraw(CashMovementRequest request)
        {
            var cash = await _repository.GetOpenCashRegister();

            if (cash == null)
                throw new Exception("Nenhum caixa aberto");

            cash.WithdrawAmount += request.Amount;

            await _repository.Update(cash);
            return "Sangria realizada";
        }
        public async Task<string> Deposit(CashMovementRequest request)
        {
            var cash = await _repository.GetOpenCashRegister();

            if (cash == null)
                throw new Exception("Nenhum caixa aberto");

            cash.DepositAmount += request.Amount;

            await _repository.Update(cash);
            return "Suprimento realizado";
        }
        public async Task<CashRegister?> GetOpen()
        {
            return await _repository.GetOpenCashRegister();
        }
    }
}

using API_.NET.Domain.Entities;


namespace API_.NET.Application.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken?> GetByToken(string token);
        Task Create(RefreshToken refreshToken);
        Task Update(RefreshToken refreshToken);
    }
}

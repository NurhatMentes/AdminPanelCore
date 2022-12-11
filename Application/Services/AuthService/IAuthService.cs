using Core.Security.JWT;
using Domain.Entities;
using Core.Security.Entities;

namespace Application.Services.AuthService
{
    public interface IAuthService
    {
        public Task<AccessToken> CreateAccessToken(ExtendedUser extendUser);
        public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
        public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
    }
}

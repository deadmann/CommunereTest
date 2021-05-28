using CommunereTest.Domain.Models;

namespace CommunereTest.Domain.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(string username);
        JwtPayload GetTokenPayload(string token);
        bool IsValidToken(string token);
    }
}

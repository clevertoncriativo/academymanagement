using academymanagement.Domain.Entities;

namespace academymanagement.Domain.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}

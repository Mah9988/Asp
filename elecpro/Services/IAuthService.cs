using elecpro.Dtos;
using elecpro.Models;
using System.Threading.Tasks;

namespace elecpro.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterDto mdoel);
        Task<AuthModel> GetTokenAsync(TokenRequestDto model);
    }
}

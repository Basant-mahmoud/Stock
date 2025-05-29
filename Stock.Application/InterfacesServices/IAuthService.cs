using Stock.Stock.Domain.Models;

namespace Stock.Stock.Application.InterfacesServices
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> LoginAsync(LoginModel model);
        Task<string> AddRoleAsync(AddRoleModel mode);

    }
}

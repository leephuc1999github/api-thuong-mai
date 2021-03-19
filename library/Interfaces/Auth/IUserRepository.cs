using library.Models.Auth;
using library.Models.Base;
using System.Threading.Tasks;

namespace library.Interfaces.Auth
{
    public interface IUserRepository 
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);
        Task<UserManagerResponse> LoginUserAsync(LoginViewModel model);
    }
}

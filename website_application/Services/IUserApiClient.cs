using System.Threading.Tasks;
using view_model.Common;
using view_model.System.Users;

namespace admin_webapp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
        Task<PagedResult<UserVm>> GetUsersPaging(GetUserPagingRequest request);
    }
}

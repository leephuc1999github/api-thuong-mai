using System.Collections.Generic;
using System.Threading.Tasks;
using view_model.Common;
using view_model.System.Roles;

namespace admin_webapp.Services.Category
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleVm>>> GetAll();
    }
}

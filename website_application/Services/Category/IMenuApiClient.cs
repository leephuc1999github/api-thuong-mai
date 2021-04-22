using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using view_model.Common;
using view_model.Utilities.Menus;

namespace admin_webapp.Services.Category
{
    public interface IMenuApiClient
    {
        Task<List<MenuItemVm>> GetAll();
        Task<ApiResult<bool>> CreateMenuItem(MenuItemVm request);
    }
}

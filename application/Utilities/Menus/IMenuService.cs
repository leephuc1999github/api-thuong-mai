using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using view_model.Utilities.Menus;

namespace application.Utilities.Menus
{
    public interface IMenuService
    {
        Task<List<MenuItemVm>> GetAll();
    }
}

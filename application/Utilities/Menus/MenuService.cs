using library.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using view_model.Utilities.Menus;

namespace application.Utilities.Menus
{
    public class MenuService : IMenuService
    {
        private readonly EShopDbContext _dbContext;
        public MenuService(EShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<MenuItemVm>> GetAll()
        {
            var menuItems = await _dbContext.MenuItems.OrderBy(mi => mi.SortOrder)
                            .Select(mi => new MenuItemVm()
                            {
                                Id = mi.Id,
                                SortOrder = mi.SortOrder,
                                Icon = mi.Icon,
                                ParentId = mi.ParentId,
                                State = "",
                                Text = mi.Text,
                                A_Attr = "",
                                Li_Attr = ""
                            }).ToListAsync();
            return menuItems;
        }
    }
}

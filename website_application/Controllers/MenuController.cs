using admin_webapp.Models;
using admin_webapp.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace admin_webapp.Controllers
{
    public class MenuController : BaseController
    {
        private readonly IMenuApiClient _menuApiClient;
        public MenuController(IMenuApiClient menuApiClient) 
        {
            _menuApiClient = menuApiClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _menuApiClient.GetAll();
            List<MenuItemViewModel> menuItems = new List<MenuItemViewModel>();
            foreach(var item in result)
            {
                menuItems.Add(new MenuItemViewModel() 
                {
                    id = item.Id + "",
                    text = item.Text,
                    parent = (item.ParentId==null?"#":(item.ParentId+""))
                });
            }
            ViewBag.MenuItems = JsonConvert.SerializeObject(menuItems);
            return View();
        }
    }
}

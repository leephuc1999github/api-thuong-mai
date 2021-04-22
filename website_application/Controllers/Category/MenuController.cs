using admin_webapp.Models;
using admin_webapp.Services.Category;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using view_model.Utilities.Menus;

namespace admin_webapp.Controllers.Category
{
    [Route("category/[controller]")]
    public class MenuController : BaseController
    {
        private readonly IMenuApiClient _menuApiClient;
        public MenuController(IMenuApiClient menuApiClient) 
        {
            _menuApiClient = menuApiClient;
        }

        [HttpGet]
        [Route("")]
        [Route("index")]
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
            ViewBag.MenuItems = menuItems.Count() == 0 ? "" : JsonConvert.SerializeObject(menuItems);
            return View();
        }

        [HttpGet]
        [Route("create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuItemVm request)
        {

            return RedirectToAction("Index");
        }
    }
}

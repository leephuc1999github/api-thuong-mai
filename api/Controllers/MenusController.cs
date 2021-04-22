using application.Utilities.Menus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using view_model.Utilities.Menus;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var menuItems = await _menuService.GetAll();
            return Ok(menuItems);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuItemVm request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //var result = _menuService.Create(request);
            return Ok(true);
        }
    }
}

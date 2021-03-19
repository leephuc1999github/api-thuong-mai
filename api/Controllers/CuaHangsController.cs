using api.Models;
using library.Interfaces;
using library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    //[Authorize]
    public sealed class CuaHangsController : ControllerBase
    {
        private readonly ICuaHangRepository _cuaHangRepository;
        public CuaHangsController(ICuaHangRepository cuaHangRepository)
        {
            _cuaHangRepository = cuaHangRepository;
        }

        [HttpGet]
        [Route("api/cuahangs")]
        public async Task<IActionResult> GetAllCuaHangs(int skip = 0, int top = 100, string q = null, string includes = null)
        {
            var result = await _cuaHangRepository.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/cuahangs/{id}")]
        public async Task<IActionResult> GetCuaHangsById(int id)
        {
            var result = await _cuaHangRepository.GetSingleById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/cuahangs")]
        public async Task<IActionResult> AddANewCuaHang(CuaHang cuaHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("validate cuaHang fault");
            }
            var result = await _cuaHangRepository.Add(cuaHang);
            return Ok(result);

        }

        [HttpPut]
        [Route("api/cuaHangs/{id}")]
        public async Task<IActionResult> UpdateCuaHangsById(int id, CuaHang cuaHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != cuaHang.ID)
            {
                return BadRequest();
            }

            var result = await _cuaHangRepository.Update(cuaHang);
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/cuaHangs/{id}")]
        public async Task<IActionResult> DeleteACuaHangById(int id)
        {
            var result = await _cuaHangRepository.Delete(id);
            return Ok(result);
        }
    }
}

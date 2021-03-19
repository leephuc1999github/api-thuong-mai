using api.Models;
using library.Interfaces;
using library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    //[Authorize]
    public sealed class NhanVienDaiDiensController : ControllerBase
    {
        private readonly INhanVienDaiDienRepository _nhanVienDaiDienRepository;
        public NhanVienDaiDiensController(INhanVienDaiDienRepository nhanVienDaiDienRepository)
        {
            _nhanVienDaiDienRepository = nhanVienDaiDienRepository;
        }

        [HttpGet]
        [Route("api/nhanviendaidiens")]
        public async Task<IActionResult> GetAllNhanVienDaiDiens(int skip = 0, int top = 100, string q = null, string includes = null)
        {
            var result = await _nhanVienDaiDienRepository.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/nhanviendaidiens/{id}")]
        public async Task<IActionResult> GetNhanVienDaiDiensById(int id)
        {
            var result = await _nhanVienDaiDienRepository.GetSingleById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/nhanviendaidiens")]
        public async Task<IActionResult> AddANewNhanVienDaiDien(NhanVienDaiDien nhanVienDaiDien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("validate nhanviendaidiens fault");
            }
            var result = await _nhanVienDaiDienRepository.Add(nhanVienDaiDien);
            return Ok(result);

        }

        [HttpPut]
        [Route("api/nhanviendaidiens/{id}")]
        public async Task<IActionResult> UpdateNhanVienDaiDiensById(int id, NhanVienDaiDien nhanVienDaiDien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != nhanVienDaiDien.ID)
            {
                return BadRequest();
            }

            var result = await _nhanVienDaiDienRepository.Update(nhanVienDaiDien);
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/nhanviendaidiens/{id}")]
        public async Task<IActionResult> DeleteANhanVienDaiDienById(int id)
        {
            var result = await _nhanVienDaiDienRepository.Delete(id);
            return Ok(result);
        }
    }
}

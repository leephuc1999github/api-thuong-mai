using api.Models;
using library.Interfaces;
using library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    //[Authorize]
    public sealed class HopDongsController : ControllerBase
    {
        private readonly IHopDongRepository _hopDongRepository;
        public HopDongsController(IHopDongRepository cuaHangRepository)
        {
            _hopDongRepository = cuaHangRepository;
        }

        [HttpGet]
        [Route("api/hopdongs")]
        public async Task<IActionResult> GetAllHopDongs(int skip = 0, int top = 100, string q = null, string includes = null)
        {
            var result = await _hopDongRepository.GetHopDongs(skip , top , q , includes);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/hopdongs/{id}")]
        public async Task<IActionResult> GetHopDongsById(int id)
        {
            var result = await _hopDongRepository.GetSingleById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/hopdongs")]
        public async Task<IActionResult> AddANewHopDong(HopDong hopDong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("validate cuaHang fault");
            }
            var result = await _hopDongRepository.Add(hopDong);
            return Ok(result);

        }

        [HttpPut]
        [Route("api/hopdongs/{id}")]
        public async Task<IActionResult> UpdateHopDongsById(int id, HopDong hopDong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != hopDong.ID)
            {
                return BadRequest();
            }

            var result = await _hopDongRepository.Update(hopDong);
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/hopdongs/{id}")]
        public async Task<IActionResult> DeleteAHopDongById(int id)
        {
            var result = await _hopDongRepository.Delete(id);
            return Ok(result);
        }
    }
}

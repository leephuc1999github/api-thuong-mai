using library.Interfaces;
using library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    //[Authorize]
    public sealed class DoiTacsController : ControllerBase
    {
        private readonly IDoiTacRepository _doiTacRepository;
        public DoiTacsController(IDoiTacRepository doiTacRepository )
        {
            _doiTacRepository = doiTacRepository;
        }

        [HttpGet]
        [Route("api/doitacs")]
        public async Task<IActionResult> Gets(int skip = 0 , int top = 100 , string q = null , string includes = null , string orderBys = null)
        {
            var result = await _doiTacRepository.Gets(skip , top , q , includes , orderBys);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/doitacs/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _doiTacRepository.GetSingleById(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("api/doitacs")]
        public async Task<IActionResult> Add([FromBody] DoiTac doiTac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("validate doitac fault");
            }
            var result = await _doiTacRepository.Add(doiTac);
            return Ok(result);

        }

        [HttpPut]
        [Route("api/doitacs/{id}")]
        public async Task<IActionResult> Update(int id ,[FromBody] DoiTac doiTac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != doiTac.ID)
            {
                return BadRequest();
            }
            
            var result = await _doiTacRepository.Update(doiTac);
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/doitacs/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             var result = await _doiTacRepository.Delete(id);
             return Ok(result);
        }
    }
}

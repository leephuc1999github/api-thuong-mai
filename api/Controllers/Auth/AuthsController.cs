using library.Interfaces.Auth;
using library.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    public sealed class AuthsController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public AuthsController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("api/auths/register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userRepository.RegisterUserAsync(model);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("some properties are not valid");
        }

        [HttpPost]
        [Route("api/auths/login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userRepository.LoginUserAsync(model);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("some properties are not valid");
        }

        [HttpGet]
        [Route("api/auths/welcome")]
        public IActionResult WelcomeUserAsync()
        {
            return Ok("Welcome to my service . let's relax with it");
        }
    }
}

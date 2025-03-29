using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserService userService, ILogger<AuthController> logger) : ControllerBase
    {
        private readonly IUserService _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        private readonly ILogger<AuthController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        [HttpPost]
        public async Task<IActionResult> Register(Core.DTO.RegisterRequest registerRequest)
        {
            try
            {
                return Ok(await _userService.Register(registerRequest));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured at {nameof(Register)}");
                return Problem();
            }
        }

        public async Task<IActionResult> Login(Core.DTO.LoginRequest loginRequest)
        {
            try
            {
                return Ok(await _userService.Login(loginRequest));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured at {nameof(Login)}");
                return Problem();
            }
        }
    }
}

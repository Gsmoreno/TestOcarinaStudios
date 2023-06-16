using Microsoft.AspNetCore.Mvc;
using OcarinaTestApi.Domains;
using OcarinaTestApi.Inteface;
using OcarinaTestApi.Model;

namespace OcarinaTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(User usuarioDto)
        {
            return Json(await _authRepository.Login(usuarioDto.Email, usuarioDto.Password));
        }
    }
}

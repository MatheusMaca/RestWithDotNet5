using Microsoft.AspNetCore.Mvc;
using RestWithDotNet5.Busines;
using RestWithDotNet5.Data.VO;

namespace RestWithDotNet5.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class AuthController : Controller
    {
        private ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO user)
        {
            if (user == null)
                return BadRequest("Invalid client request");

            var token = _loginBusiness.ValidateCredentials(user);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}

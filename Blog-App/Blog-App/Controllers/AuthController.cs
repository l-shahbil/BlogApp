using Blog_App.Models;
using Blog_App.Models.Dto;
using Blog_App.Repository.Base;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography.Xml;

namespace Blog_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRepository<user> _repoUser;

        public AuthController(IRepository<user>repoUser)
        {
            _repoUser = repoUser;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user =(await _repoUser.GetAllAsync(x => x.Email == model.Email)).FirstOrDefault();
            if (user != null && user.Password ==model.Password) 
            {
                ClaimsPrincipal claim = new ClaimsPrincipal(new ClaimsIdentity(
                    new[] {new Claim(ClaimTypes.Name,user.Email)},
                    BearerTokenDefaults.AuthenticationScheme
                    ));
                return SignIn(claim);
            }
            return BadRequest(ModelState);
        }
    }
}

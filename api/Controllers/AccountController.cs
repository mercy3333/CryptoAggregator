using api.Dtos.Account;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace api.Controllers
{
        [Route("api/account")]
        [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;

        public AccountController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var User = new User
                {
                    UserName = registerDto.username,
                    Email = registerDto.email
                };

                var createdUser = await userManager.CreateAsync(User, registerDto.password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(User, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok("User registered");
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }
        }

    }
}

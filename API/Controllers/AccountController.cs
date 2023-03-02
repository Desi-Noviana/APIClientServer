using API.Models;
using API.Repositories.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountRepository repository;

        public AccountController(AccountRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterVM registerVM)
        {
            try
            {
                var result = await repository.Register(registerVM);
                return result is 0
                    ? Conflict(new { statusCode = 409, message = "Data fail to Insert!" })
                    : Ok(new { statusCode = 200, message = "Data Saved Succesfully!" });
            }
            catch
            {
                return BadRequest(new { statusCode = 400, message = "Something Wrong!" });
            }
        }
        [HttpPost("/Login")]
        public async Task<ActionResult> Login(LoginVM loginVM)
        {
            try
            {
                var result = await repository.Login(loginVM);
                return result is false
                    ? Conflict(new { statusCode = 409, message = "Account or Password Does Not Match!" })
                    : Ok(new { statusCode = 200, message = "Login Success!" });
            }
            catch
            {
                return BadRequest(new { statusCode = 400, message = "Something Wrong!" });
            }
           
        }
    }
}

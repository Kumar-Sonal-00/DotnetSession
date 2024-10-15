using AspNetIdentityManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetIdentityManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser(string userName,string email,string password)
        {
            var user=new IdentityUser { UserName = userName, Email = email };
            var result = await userManager.CreateAsync(user,password);
            if (result.Succeeded)
            {
                return Ok("User registered successfully");
            }
            else
            {
                return BadRequest("could not register user");
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string userName,string password )
        {
            var user=new IdentityUser { UserName= userName };
            await signInManager.SignInAsync(user, false);
            return Ok("logged in");                                
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok("logged-out");
        }
    }
}

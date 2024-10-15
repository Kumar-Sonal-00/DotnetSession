using EmployeeServiceAPI.Models;
using EmployeeServiceAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserDbContext dbCtx;
        private readonly IConfiguration _config;
        public AccountController(UserDbContext dbCtx,IConfiguration config)
        {
            this.dbCtx = dbCtx;
            this._config = config;
        }

        [HttpPost]
        [Route("authenticate")]
        public IActionResult Login(UsersDetails user)
        {
            var record = dbCtx.tbl_users.Where(o => o.UserName == user.UserName && o.Password == user.Password && o.Role == user.Role)
                              .SingleOrDefault();

            if (record!=null)
            {               
                //generate jwt token and return 
                var keyBytes = Encoding.UTF8.GetBytes(_config["JWT:Key"]);

                var tokenDescriptor = new JwtSecurityToken(
                    issuer: _config["JWT:Issuer"],
                    audience: _config["JWT:Audience"],
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature),
                    claims:new List<Claim>
                    {
                        new Claim(ClaimTypes.Role,user.Role)
                    });

                var tokenHandler = new JwtSecurityTokenHandler();
                return Ok(tokenHandler.WriteToken(tokenDescriptor));
            }
            else
            {
                return BadRequest("invalid user and password");
            }
        }
    }
}

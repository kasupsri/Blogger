using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BloggerAPI.Configuration;
using BloggerAPI.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BloggerAPI.Controllers
{
    [Route("api/[controller]")] // api/authManagement
    [ApiController]
    public class AuthManagementController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;

        public AuthManagementController(UserManager<IdentityUser> userManager,IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegister)
        {
            if(ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(userRegister.Email);

                if(existingUser != null)
                {
                    return BadRequest("Email already in use");
                }

                var newUser = new IdentityUser()   
                {   Email = userRegister.Email, 
                    UserName = userRegister.Name, 
                    PhoneNumber = userRegister.Phone
                };
                var isCreated = await _userManager.CreateAsync(newUser, userRegister.Password);
                if(isCreated.Succeeded)
                {
                    var jwtToken = GenerateJwtToken(newUser);
                    return Ok(new { Token = jwtToken});
                }
                else
                {
                    return BadRequest(isCreated.Errors.Select(x=> x.Description).ToList());
                }
            }
            return BadRequest("Invalid request");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLoginDto userLogin)
        {
            if(ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(userLogin.Email);
                if(existingUser == null)
                {
                    return BadRequest("Invalid login request");
                }

                var isCorrect = await _userManager.CheckPasswordAsync(existingUser,userLogin.Password);
                if(!isCorrect)
                {
                    return BadRequest("Invalid login request");
                }

                var jwtToken = GenerateJwtToken(existingUser);
                return Ok(new {Token = jwtToken});
            }
            return BadRequest("Invalid login request");
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new []
                {
                    new Claim("Id",user.Id),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
        
    }
}
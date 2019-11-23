using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthServer1.Models;
using AuthServer1.Services;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthServer1.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserService _service;

        public AuthController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("register")]

        public IActionResult Register([FromBody]User user)
        {
            try
            {
                _service.RegisterUser(user);
                return StatusCode(201, "you successfully registered");
            }
            catch(UserAlreadyExistsException ue)
            {
                return Conflict(ue.Message);
            }
            catch(Exception)
            {
                return StatusCode(500, "there is some server error");
            }
        }


        [HttpPost]
        [Route("login")]

        public IActionResult Login([FromBody]User user)
        {
            try
            {
                string userId = user.UserId;
                string password = user.Password;

                User _user = _service.Login(userId, password);

                string value = this.GetJWTToken(userId);

                return Ok(value);
            }
            catch (UserNotFoundException unf)
            {
                return NotFound(unf.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "there is some server error");
            }
        }

        private string GetJWTToken(string userId)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName,userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("authserver_secret_to_validate_token"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "AuthServer",
                audience: "jwtclient",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(20),
                signingCredentials: creds
            );

            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return JsonConvert.SerializeObject(response);
        }
    }
}

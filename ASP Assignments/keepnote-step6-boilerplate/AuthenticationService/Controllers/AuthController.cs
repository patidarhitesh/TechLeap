using AuthenticationService.Exceptions;
using AuthenticationService.Models;
using AuthenticationService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationService.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    /*
   As in this assignment, we are working with creating RESTful web service to create microservices, hence annotate
   the class with [ApiController] annotation and define the controller level route as per REST Api standard.
   */
    public class AuthController : Controller
    {
        /*
       AuthService should  be injected through constructor injection. Please note that we should not create service
       object using the new keyword

      */
        private readonly IAuthService _service;
        public AuthController(IAuthService authService)
        {
            _service = authService;
        }

        /*
	     * Define a handler method which will create a specific user by reading the
	     * Serialized object from request body and save the user details in the
	     * database. This handler method should return any one of the status messages
	     * basis on different situations:
	     * 1. 201(CREATED) - If the user created successfully. 
	     * 2. 409(CONFLICT) - If the userId conflicts with any existing user
	     * 
	     * This handler method should map to the URL "/api/auth/register" using HTTP POST method
    	 */

        [HttpPost]
        [Route("register")]

        public IActionResult Register([FromBody]User user)
        {
            try
            {
               
                return StatusCode(201, _service.RegisterUser(user));
            }
            catch (UserAlreadyExistsException ue)
            {
                return Conflict($"This userId {user.UserId} already in use");
            }
            catch (Exception)
            {
                return StatusCode(500, "there is some server error");
            }
        }


        /* Define a handler method which will authenticate a user by reading the Serialized user
         * object from request body containing the username and password. The username and password should be validated 
         * before proceeding ahead with JWT token generation. The user credentials will be validated against the database entries. 
         * The error should be return if validation is not successful. If credentials are validated successfully, then JWT
         * token will be generated. The token should be returned back to the caller along with the API response.
         * This handler method should return any one of the status messages basis on different
         * situations:
         * 1. 200(OK) - If login is successful
         * 2. 401(UNAUTHORIZED) - If login is not successful
         * 
         * This handler method should map to the URL "/api/auth/login" using HTTP POST method
        */
        [HttpPost]
        [Route("login")]

        public IActionResult Login([FromBody]User user)
        {
            try
            {
                string userId = user.UserId;
                string password = user.Password;
               
                
                _service.LoginUser(user);
                if (_service.LoginUser(user))
                {
                    string value = this.GetJWTToken(userId);
                    return Ok(value);
                }

                return StatusCode(401, "Invalid user id or password");
                
                
            }
           
            catch (Exception)
            {
                return StatusCode(401,"Login failed");
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

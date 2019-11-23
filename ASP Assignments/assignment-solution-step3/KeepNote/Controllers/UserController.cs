using Entities;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace KeepNote.Controllers
{
    /*
     * As in this assignment, we are working with creating RESTful web service, hence annotate
     * the class with [ApiController] annotation and define the controller level route as per REST Api standard.
     */
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /*
         * UserService should  be injected through constructor injection. Please note that we should not create service
         * object using the new keyword
        */
        private readonly IUserService service;
        public UserController(IUserService userService)
        {
            service = userService;
        }

        /*
	     * Define a handler method which will create a specific user by reading the
	     * Serialized object from request body and save the user details in a User table
	     * in the database. This handler method should return any one of the status
	     * messages basis on different situations: 1. 201(CREATED) - If the user created
	     * successfully. 2. 409(CONFLICT) - If the userId conflicts with any existing
	     * user
	     * 
	     * 
	     * This handler method should map to the URL "/api/user/register" using HTTP POST
	     * method
	     */
   
        [HttpPost("register")]
        public IActionResult Post([FromBody]User user)
        {
            try
            {
                return StatusCode(201, service.RegisterUser(user));
            }

            catch (UserAlreadyExistException cnf)
            {
                return Conflict(cnf.Message);
            }

        }

        /*
         * Define a handler method which will login a specific user by reading the
         * Serialized object from request body and validate the userId and Password
         * from User table in the database. This handler method should return any one of 
         * the status messages basis on different situations: 
         * 1. 200(OK) - If the user successfully logged in. 
         * 2. 404(NOTFOUND) -If the user with specified userId is not found.
         * 
         * This handler method should map to the URL "/api/user/login" using HTTP POST
         * method
         */
        [HttpPost("login")]
        public IActionResult Login([FromBody]User user)
        {
            try
            {
                return Ok(service.ValidateUser(user.UserId,user.Password));
            }

            catch (UserNotFoundException cnf)
            {
                return NotFound(cnf.Message);
            }

        }
        /*
         * Define a handler method which will update a specific user by reading the
         * Serialized object from request body and save the updated user details in a
         * user table in database handle exception as well. This handler method should
         * return any one of the status messages basis on different situations: 1.
         * 200(OK) - If the user updated successfully. 2. 404(NOT FOUND) - If the user
         * with specified userId is not found. 
         * 
         * This handler method should map to the URL "/api/user/{id}" using HTTP PUT method.
         */
        [HttpPut("{userId}")]
        public IActionResult Put(string userId, [FromBody] User user)
        {
            try
            {

                return Ok(service.UpdateUser(userId, user));
            }

            catch (UserNotFoundException cnf)
            {
                return NotFound(cnf.Message);
            }


        }
        /*
         * Define a handler method which will delete a user from a database.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the user deleted successfully from
         * database. 2. 404(NOT FOUND) - If the user with specified userId is not found.
         * 
         * This handler method should map to the URL "/api/user/{id}" using HTTP Delete
         * method" where "id" should be replaced by a valid userId without {}
         */
        [HttpDelete("{userId}")]
        public IActionResult Delete(string userId)
        {
            try
            {
                return Ok(service.DeleteUser(userId));
            }
            catch (UserNotFoundException nnf)
            {
                return NotFound(nnf.Message);
            }
        }
        /*
         * Define a handler method which will show details of a specific user handle
         * UserNotFoundException as well. This handler method should return any one of
         * the status messages basis on different situations: 1. 200(OK) - If the user
         * found successfully. 2. 404(NOT FOUND) - If the user with specified
         * userId is not found. This handler method should map to the URL "/api/user/{userId}"
         * using HTTP GET method where "id" should be replaced by a valid userId without
         * {}
         */
         
        [HttpGet("{Id}")]
        public IActionResult Get(string Id)
        {
            try
            {
                return Ok(service.GetUserById(Id));
            }
            catch (UserNotFoundException cnf)
            {
                return NotFound(cnf.Message);
            }

        }
    }
}

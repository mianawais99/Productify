using DbModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Productify.Repo;
using Productify.Service.CustomException;
using Productify.Service.ICustomServices;

namespace Productify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICustomService<User> _customService;
        private readonly ApplicationContext _applicationDbContext;
        public UserController(ICustomService<User> customService, ApplicationContext applicationDbContext)
        {
            _customService = customService;
            _applicationDbContext = applicationDbContext;
        }


        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/User/CreateUser
        ///     {
        ///        "addedDate": "2024-03-29T19:29:47.525Z",
        ///        "modifiedDate": "2024-03-29T19:29:47.525Z",
        ///        "userName": "mianawais",
        ///        "email": "awais@gmail.com",
        ///        "password": "12345",
        ///        "addressId": 0,
        ///        "address": {
        ///          "street": "New Street",
        ///          "city": "Lahore",
        ///          "state": "Punjab",
        ///          "zipCode": "54000"
        ///        }
        ///     }
        ///
        /// </remarks>
        /// <param name="user">The user object to create.</param>
        /// <returns>A response indicating success or failure.</returns>
        [HttpPost(nameof(CreateUser))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult CreateUser(User user)
        {
            if (user != null)
            {
                try
                {
                    _customService.Insert(user);
                    return Ok("Created Successfully");
                }
                catch (DuplicateEntryException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (Exception)
                {
                    return BadRequest("Something went wrong");
                }
            }
            else
            {
                return BadRequest("Invalid user object.");
            }
        }
    }
}

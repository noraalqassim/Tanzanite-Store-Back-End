using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Entity;
using src.Services.User;
using src.Utils;
using static src.DTO.UserDTO;

namespace src.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController] //User
    public class UserController : ControllerBase
    {
        /// <summary>
        /// make the list static so all the sellers and the customers access it.
        /// make lis info.
        /// get, post, put and delete method for user without consider is(seller, customer).
        /// </summary>


        protected readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <API>
        /// {
        //     "name": "",
        //     "phoneNumber": "",
        //     "email": "",
        //     "password": ""
        //  }
        /// </API>
        /// return user info

        [HttpPost("SignUp")] //SignUp
        public async Task<ActionResult<UserCreateDto>> CreateOne([FromBody] UserCreateDto createDto)
        {
            var userCretaed = await _userService.CreateOneAsync(createDto);
            return Ok(userCretaed);
        }

        /// <API>
        ///{
        //     "email": "",
        //     "password": ""
        // }
        /// </API>
        /// return Token

        [HttpPost("LogIn")] //Login
        public async Task<ActionResult<string>> LogInOne([FromBody] UserLoginDto createDto)
        {
            var token = await _userService.LogInAsync(createDto);
            return Ok(token);
        }

        /// <summary>
        /// get all user info
        /// </summary>

        [HttpGet]
        [Authorize] // --> For users
        //[Authorize(Roles ="Admin")] //--> For admins
        public async Task<ActionResult<List<UserReadDto>>> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();

            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserReadDto>> GetByIdAsync(Guid userId)
        {
            var foundUser = await _userService.GetByIdAsync(userId);
            if (foundUser == null)
            {
                return NotFound("there is no user in this name");
            }

            return Ok(foundUser);
        }
    }
}

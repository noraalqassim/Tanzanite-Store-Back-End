using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserCreateDto>> CreateOne(UserCreateDto createDto)
        {
            var userCretaed = await _userService.CreateOneAsync(createDto);
            return Ok(userCretaed);
        }

        [HttpGet]
        public async Task<ActionResult<UserReadDto>> GetAllAsync()
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


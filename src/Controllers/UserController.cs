using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
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
        protected readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
            //  _userService = new UserService{};
        }
        

        [HttpPost("Register")]
        public async Task<ActionResult<UserCreateDto>> CreateOne([FromBody] UserCreateDto createDto)
        {
            var userCretaed = await _userService.CreateOneAsync(createDto);
            if (userCretaed == null)
            {
                return Conflict("The email is already in use.");
            }
            return Ok(userCretaed);
        }

        [HttpPost("Admin/SignUp")]
        public async Task<ActionResult<UserCreateDto>> CreateAdminOne([FromBody] UserCreateDto createDto)
        {
            var userCretaed = await _userService.CreateAdminAsync(createDto);
            if (userCretaed == null)
            {
                return Conflict("The email is already in use.");
            }
            return Ok(userCretaed);
        }

        [HttpPost("LogIn")]
        public async Task<ActionResult<string>> LogInOne([FromBody] UserLoginDto createDto)
        {
            var token = await _userService.LogInAsync(createDto);
            System.Console.WriteLine($"token:{token}");
            return Ok(token);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<UserReadDto>>> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();

            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }

        [HttpGet("Profile")]
        [Authorize]
        public async Task<ActionResult<UserProfileDto>> GetProfileIdAsync()
        {
            var authenticatedClaims = HttpContext.User;
            var userId = authenticatedClaims.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userGuid = new Guid(userId);
            var user = await _userService.GetByIdAsync(userGuid);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }

        [Authorize]
        [HttpPatch("UpdateProfile/{userId}")]
        public async Task<ActionResult<UserProfileDto>> UpdateProfileAsync([FromRoute] Guid userId,UserUpdateDto updateDto)
        {
            var updatedUserDto = await _userService.UpdateOneAsync(userId, updateDto);
            return Ok(updatedUserDto);
        }

        [HttpPut("UpdatePassword")]
        [Authorize]
        public async Task<ActionResult<bool>> UpdatePassword(PasswordUpdateDto updateDto)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var isUpdated = await _userService.UpdatePasswordAsync(userId, updateDto);

            if (!isUpdated)
            {
                return NotFound("User not found.");
            }

            return Ok(isUpdated);
        }
    }
}

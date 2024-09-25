using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Entity;
using src.Utils;

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
        public static List<Users> users = new List<Users>
        {
            new Users
            {
                Name = "Retaj",
                PhoneNumber = "+966222222222",
                Email = "Retaj@example.com",
                Password = "RX",
            },
            new Users
            {
                Name = "Nora",
                PhoneNumber = "+966111111111",
                Email = "Nora@example.com",
                Password = "NX",
            },
            new Users
            {
                Name = "Ethra",
                PhoneNumber = "+966333333333",
                Email = "Ethra@example.com",
                Password = "EX",
            },
            new Users
            {
                Name = "Weed",
                PhoneNumber = "+9664444444444",
                Email = "Weed@example.com",
                Password = "WX",
            },
            new Users
            {
                Name = "Rahaf",
                PhoneNumber = "+966555555555",
                Email = "Rahaf@example.com",
                Password = "RX",
            },
        };

        [HttpGet]
        public ActionResult GetUser()
        {
            if (users.Count == 0)
            {
                return NotFound("it's empty!");
            }

            return Ok(users);
        }

        [HttpGet("{name}")]
        public ActionResult GetUserByName(String name)
        {
            var user = users.FirstOrDefault(i => i.Name == name);
            if (users == null || users.Count == 0)
            {
                return NotFound("there is no user in this name");
            }

            return Ok(user);
        }

        [HttpPost("Signup")]
        public ActionResult SignUpUser(Users newUser)
        {
            var existingUser = users.FirstOrDefault(u =>
                u.Email == newUser.Email || u.PhoneNumber == newUser.PhoneNumber
            );

            if (existingUser != null)
            {
                return Conflict(
                    $"{newUser.Name} User with This email or phone number already exists"
                );
            }

            PasswordUtils.HashPassword(
                newUser.Password,
                out string hashedPassword,
                out byte[] salt
            );

            newUser.Password = hashedPassword;

            newUser.Salt = salt;

            users.Add(newUser);
            return CreatedAtAction(nameof(GetUserByName), new { id = newUser.UserId }, newUser);
        }

        [HttpPost("Login")]
        public ActionResult LogInUser(Users user)
        {
            Users foundUser = users.FirstOrDefault(u => u.Email == user.Email);
            if (foundUser == null)
            {
                return NotFound("The email is not exist");
            }

            bool isMatch = PasswordUtils.VerifyPassword(
                user.Password,
                foundUser.Password,
                foundUser.Salt
            );

            if (!isMatch)
            {
                return Unauthorized();
            }
            return Ok("Welcome back !" + foundUser);
        }
        /*
                [HttpPut("{id}")]
                public ActionResult UpdateUser(int id, Users updatedUser)
                {
                    Users existingUser = users.FirstOrDefault(i => i.UserId == id);
        
                    if (existingUser == null)
                    {
                        return NotFound("User not found");
                    }
        
                    existingUser.Name = updatedUser.Name;
                    existingUser.PhoneNumber = updatedUser.PhoneNumber;
                    existingUser.Email = updatedUser.Email;
                    existingUser.Password = updatedUser.Password;
        
                    return Ok($"User information updated: {existingUser}");
                }
        
                [HttpDelete("{id}")]
                public ActionResult DeleteUser(int id)
                {
                    var userToDelete = users.FirstOrDefault(u => u.UserId == id);
        
                    if (userToDelete == null)
                    {
                        return NotFound("User not found");
                    }
        
                    users.Remove(userToDelete);
        
                    return Ok($"User deleted successfully");
                }
                */
    }
}

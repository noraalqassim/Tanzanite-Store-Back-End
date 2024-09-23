using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Entity;

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
                UserId = 1,
                Name = "Retaj",
                PhoneNumber = "+966222222222",
                Email = "Retaj@example.com",
                Password = "RX",
                IsCustomer = true,
                IsSeller = false,
            },
            new Users
            {
                UserId = 2,
                Name = "Nora",
                PhoneNumber = "+966111111111",
                Email = "Nora@example.com",
                Password = "NX",
                IsCustomer = true,
                IsSeller = false,
            },
            new Users
            {
                UserId = 3,
                Name = "Ethra",
                PhoneNumber = "+966333333333",
                Email = "Ethra@example.com",
                Password = "EX",
                IsCustomer = false,
                IsSeller = true,
            },
            new Users
            {
                UserId = 4,
                Name = "Weed",
                PhoneNumber = "+9664444444444",
                Email = "Weed@example.com",
                Password = "WX",
                IsCustomer = true,
                IsSeller = false,
            },
            new Users
            {
                UserId = 5,
                Name = "Rahaf",
                PhoneNumber = "+966555555555",
                Email = "Rahaf@example.com",
                Password = "RX",
                IsCustomer = false,
                IsSeller = true,
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
        public ActionResult GetUserByName(string name)
        {
            var user = users.FirstOrDefault(i => i.Name == name);
            if (users == null || users.Count == 0)
            {
                return NotFound("there is no user in this name");
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult PostUser(Users newUser)
        {
            var existingUser = users.FirstOrDefault(u => u.UserId == newUser.UserId);

            if (existingUser != null)
            {
                return Conflict($"User with ID {newUser.UserId} already exists");
            }

            users.Add(newUser);

            return Ok($"New user created: {newUser}");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, Users updatedUser)
        {
            var existingUser = users.FirstOrDefault(i => i.UserId == id);

            if (existingUser == null)
            {
                return NotFound("User not found");
            }

            existingUser.Name = updatedUser.Name;
            existingUser.PhoneNumber = updatedUser.PhoneNumber;
            existingUser.Email = updatedUser.Email;
            existingUser.Password = updatedUser.Password;
            existingUser.IsCustomer = updatedUser.IsCustomer;
            existingUser.IsSeller = updatedUser.IsSeller;

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
    }
}

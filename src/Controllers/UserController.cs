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
        public List<Users> users = new List<Users>
        {
            new Users
            {
                UserId = 2,
                Name = "Retaj",
                PhoneNumber = "+966222222222",
                Email = "Retaj@example.com",
                Password = "RX",
                IsCustomer = true,
                IsSeller = false,
            },
            new Users
            {
                UserId = 1,
                Name = "Nora",
                PhoneNumber = "+966111111111",
                Email = "Nora@example.com",
                Password = "NX",
                IsCustomer = true,
                IsSeller = false,
            },
            new Users
            {
                UserId = 4,
                Name = "Ethra",
                PhoneNumber = "+966333333333",
                Email = "Ethra@example.com",
                Password = "EX",
                IsCustomer = false,
                IsSeller = true,
            },
            new Users
            {
                UserId = 5,
                Name = "Weed",
                PhoneNumber = "+9664444444444",
                Email = "Weed@example.com",
                Password = "WX",
                IsCustomer = true,
                IsSeller = false,
            },
            new Users
            {
                UserId = 6,
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
                return Ok("there is no user yet!");
            }

            return Ok(users);
        }
    }
}

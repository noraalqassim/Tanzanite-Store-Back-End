using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Entity;

namespace src.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController] //Seller
    public class SellerController : ControllerBase
    {
        private List<Users> _users;
        private List<Users> _sellerUsers;

        public SellerController()
        {
            _users = UserController.users;
            _sellerUsers = _users.Where(u => u.IsSeller).ToList();
        }

        [HttpGet]
        public ActionResult GetSellerUsers()
        {
            return Ok(_sellerUsers);
        }

        [HttpGet("{name}")]
        public ActionResult GetUserByName(string name)
        {
            var seller = _sellerUsers.FirstOrDefault(i => i.Name == name);

            if (seller == null)
            {
                return NotFound("User not found");
            }

            return Ok(seller);
        }

        [HttpPost]
        public ActionResult PostUser(Users newUserSeller)
        {
            var existingUser = _sellerUsers.FirstOrDefault(u => u.UserId == newUserSeller.UserId);
            newUserSeller.IsSeller = true;

            if (existingUser != null)
            {
                return Conflict($"User with ID {newUserSeller.UserId} already exists");
            }

            _sellerUsers.Add(newUserSeller);

            return Ok($"New seller created: {newUserSeller}");
        }

        [HttpPut("{sellerId}")]
        public ActionResult UpdateUser(int sellerId, Users updatedSeller)
        {
            var sellerToUpdate = _sellerUsers.FirstOrDefault(u => u.UserId == sellerId);

            if (sellerToUpdate == null)
            {
                return NotFound("User not found");
            }

            // Update the user properties
            sellerToUpdate.Name = updatedSeller.Name;
            sellerToUpdate.PhoneNumber = updatedSeller.PhoneNumber;
            sellerToUpdate.Email = updatedSeller.Email;
            sellerToUpdate.Password = updatedSeller.Password;

            return Ok(sellerToUpdate);
        }

        [HttpDelete("{sellerId}")]
        public ActionResult DeleteUser(int sellerId)
        {
            var sellerToDelete = _sellerUsers.FirstOrDefault(u => u.UserId == sellerId);

            if (sellerToDelete == null)
            {
                return NotFound("User not found");
            }

            _sellerUsers.Remove(sellerToDelete);

            return Ok("User deleted successfully");
        }
    }
}

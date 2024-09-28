using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;

namespace src.DTO
{
    public class UserDTO
    {
        /// <summary>
        /// Data Transfer Object (DTO)
        ///This DTO is designed to encapsulate all necessary information.
        /// transfer data between different parts of an application,
        /// such as between services, and repositories.
        /// Mapper used the class down there.
        /// Contains user details such as name, phone number, email, password, addresses, salt for password hashing,and admin status.
        /// add two scenarios:
        /// 1- user login, only the email and password fields may be required.
        /// 2- user forgot password, only the password fields may be required.
        /// </summary>

        public class UserCreateDto //can use for signUp
        {
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public bool IsAdmin { get; set; }
        }

        public class UserReadDto
        {
            public Guid UserId { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public byte[]? Salt { get; set; }
            public bool IsAdmin { get; set; }
        }

        public class UserUpdateDto
        {
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public bool IsAdmin { get; set; }
        }

        public class UserLoginDto
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class PasswordUpdateDto
        {
            public string Password { get; set; }
        }
    }
}

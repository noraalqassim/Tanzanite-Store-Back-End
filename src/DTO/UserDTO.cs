using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;
using static src.DTO.AddressDTO;

namespace src.DTO
{
    public class UserDTO
    {
        public class UserCreateDto
        {
            [Required(ErrorMessage = "Name is required.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Phone number is required.")]
            [RegularExpression(@"^\+[1-9]\d{1,14}$", ErrorMessage = "Phone number must start with a '+' followed by the country code and up to 14 digits. Example: +966123456789.")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Please enter a valid email address. Example: user@example.com.")]
            public string Email { get; set; }

            [Required]
            [MinLength(8)]
            [RegularExpression(
                @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$",
                ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit."
            )]
            public string Password { get; set; }
        }

        public class UserReadDto
        {
            public Guid UserId { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public Role Role { get; set; }
        }

        public class AdminUpdateDto
        {
            public Guid UserId { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public Role Role { get; set; }
        }

        public class UserLoginDto
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class UserProfileDto
        {
            public Guid UserId { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public ICollection<AddressReadDto> Addresses { get; set; } = new List<AddressReadDto>();
        }

        public class UserUpdateDto
        {
            public string? Name { get; set; }

            [RegularExpression(@"^\+[1-9]\d{1,14}$", ErrorMessage = "Phone number must start with a '+' followed by the country code and up to 14 digits. Example: +966123456789.")]
            public string? PhoneNumber { get; set; }

            [EmailAddress(ErrorMessage = "Please enter a valid email address. Example: user@example.com.")]
            public string? Email { get; set; }
            [MinLength(8)]
            [RegularExpression(
                @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$",
                ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit."
            )]
            public string? Password { get; set; }
        }

        public class PasswordUpdateDto
        {
            [Required]
            [MinLength(8)]
            [RegularExpression(
                @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$",
                ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit."
            )]
            public string Password { get; set; }
        }

    }
}

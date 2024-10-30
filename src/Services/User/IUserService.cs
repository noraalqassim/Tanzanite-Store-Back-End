using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static src.DTO.UserDTO;

namespace src.Services.User
{
    public interface IUserService
    {
        Task<UserReadDto> CreateOneAsync(UserCreateDto createDto);
        Task<UserReadDto?> CreateAdminAsync(UserCreateDto createDto);
        Task<List<UserReadDto>> GetAllAsync();
        Task<UserReadDto> GetByIdAsync(Guid userId);
        Task<bool> DeleteOneAsync(Guid userId);
        Task<string> LogInAsync(UserLoginDto createDto);
        Task<UserProfileDto> GetProfileIdAsync(Guid userId);
        Task<UserProfileDto> UpdateOneAsync(Guid userId, UserProfileDto updateDto);
        Task<bool> UpdatePasswordAsync(Guid userId, PasswordUpdateDto updateDto);
    }
}

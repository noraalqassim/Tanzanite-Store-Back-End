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
        Task<List<UserReadDto>> GetAllAsync();
        Task<UserReadDto> GetByIdAsync(Guid UserId);
        Task<bool> DeleteOneAsync(Guid UserId);
        Task<bool> UpdateOneAsync(Guid userId, UserUpdateDto updateDto);

        Task<bool> UpdateOneAsync(UserLoginDto updateDto);

        Task<bool> UpdateOneAsync(PasswordUpdateDto updateDto);
    }
}

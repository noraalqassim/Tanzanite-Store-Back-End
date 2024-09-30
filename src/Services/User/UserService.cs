using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.DTO;
using src.Entity;
using src.Repository;
using src.Utils;
using static src.DTO.UserDTO;

namespace src.Services.User
{
    /// <summary>
    /// Services Contain the business logic of your application and interact with entities, repositories, and other services.
    //  Services use DTOs to transfer data between different layers of the application, such as between the controller and the repository.
    /// </summary>
    public class UserService : IUserService
    {
        protected readonly UserRepository _userRepo;
        protected readonly IMapper _mapper;

        protected readonly IConfiguration _config;

        public UserService(UserRepository userRepo, IMapper mapper, IConfiguration config)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _config = config;
        }

        //SignUp
        public async Task<UserReadDto> CreateOneAsync(UserCreateDto createDto)
        {
            PasswordUtils.HashPassword(
                createDto.Password,
                out string hashedPassword,
                out byte[] salt
            );

            var users = _mapper.Map<UserCreateDto, Users>(createDto);
            users.Password = hashedPassword;
            users.Salt = salt;
            users.Role = Role.Customer;

            var userCreated = await _userRepo.CreateOnAsync(users);
            return _mapper.Map<Users, UserReadDto>(userCreated);
        }

        public async Task<string> LogInAsync(UserLoginDto createDto)
        {
            var foundUser = await _userRepo.FindByEmailAsync(createDto.Email);
            var passwordMatched = PasswordUtils.VerifyPassword(
                createDto.Password,
                foundUser.Password,
                foundUser.Salt
            );
            if (passwordMatched)
            {
                var tokenUtil = new TokenUtils(_config);
                return tokenUtil.GenerateToken(foundUser);
            }
            return "Unauthorized";
        }

        public async Task<bool> DeleteOneAsync(Guid userId)
        {
            var foundUser = await _userRepo.GetByIdAsync(userId);
            var isDeleted = await _userRepo.DeleteOnAsync(foundUser);
            return isDeleted;
        }

        public async Task<List<UserReadDto>> GetAllAsync()
        {
            var userList = await _userRepo.GetAllAsync();
            return _mapper.Map<List<Users>, List<UserReadDto>>(userList);
        }

        public async Task<UserReadDto> GetByIdAsync(Guid userId)
        {
            var foundUser = await _userRepo.GetByIdAsync(userId);
            return _mapper.Map<Users, UserReadDto>(foundUser);
        }

        public async Task<bool> UpdateOneAsync(Guid userId, UserUpdateDto updateDto)
        {
            var foundUser = await _userRepo.GetByIdAsync(userId);
            if (foundUser == null)
            {
                return false;
            }
            _mapper.Map(foundUser, updateDto);
            return true;
        }

        public Task<bool> UpdateOneAsync(PasswordUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}

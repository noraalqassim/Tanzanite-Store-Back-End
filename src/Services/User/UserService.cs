using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using src.DTO;
using src.Entity;
using src.Repository;
using src.Utils;
using static src.DTO.UserDTO;

namespace src.Services.User
{
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

        public async Task<UserReadDto?> CreateOneAsync(UserCreateDto createDto)
        {
            var foundUser = await _userRepo.FindByEmailAsync(createDto.Email);
            if (foundUser != null)
            {
                return null;
            }
            else
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
        }


        public async Task<UserReadDto?> CreateAdminAsync(UserCreateDto createDto)
        {
            var foundUser = await _userRepo.FindByEmailAsync(createDto.Email);
            if (foundUser != null)
            {
                return null;
            }
            else
            {
                PasswordUtils.HashPassword(
                    createDto.Password,
                    out string hashedPassword,
                    out byte[] salt
                );

                var users = _mapper.Map<UserCreateDto, Users>(createDto);

                users.Password = hashedPassword;
                users.Salt = salt;
                users.Role = Role.Admin;

                var userCreated = await _userRepo.CreateOnAsync(users);
                return _mapper.Map<Users, UserReadDto>(userCreated);
            }
        }

        public async Task<bool> DeleteOneASync(Guid id)
        {
            var foundUser = await _userRepo.GetByIdAsync(id);
            if (foundUser is not null)
            {
                return await _userRepo.DeleteOnAsync(foundUser);
            }
            return false;
        }

        public async Task<string> LogInAsync(UserLoginDto createDto)
        {
            var foundByEmail = await _userRepo.FindByEmailAsync(createDto.Email);
            if (foundByEmail is null)
            {
                throw CustomException.UnAuthorized("Dont have an account, please register");
            }
            var passwordMatched = PasswordUtils.VerifyPassword(createDto.Password, foundByEmail.Password, foundByEmail.Salt);
            if (passwordMatched)
            {
                var tokenUtils = new TokenUtils(_config);
                return tokenUtils.GenerateToken(foundByEmail);
            }
            throw CustomException.UnAuthorized("Password does not match");
            // var foundUser = await _userRepo.FindByEmailAsync(createDto.Email);
            // var passwordMatched = PasswordUtils.VerifyPassword(
            //     createDto.Password,
            //     foundUser.Password,
            //     foundUser.Salt
            // );
            // if (passwordMatched)
            // {
            //     var tokenUtil = new TokenUtils(_config);
            //     return tokenUtil.GenerateToken(foundUser);
            // }
            // // return "Password does not match";
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

        public async Task<UserProfileDto> GetProfileIdAsync(Guid userId)
        {
            var foundUser = await _userRepo.GetByIdAsync(userId);
            return _mapper.Map<Users, UserProfileDto>(foundUser);
        }

        public async Task<UserProfileDto> UpdateOneAsync(Guid userId, UserUpdateDto updateDto)
        {
            var foundUser = await _userRepo.GetByIdAsync(userId);

            if (foundUser == null)
            {
                throw CustomException.NotFound($"User with {userId} is not found");
            }

            _mapper.Map(updateDto, foundUser);

            var updatedUser = await _userRepo.UpdateOnAsync(foundUser);

            return _mapper.Map<UserProfileDto>(updatedUser);
        }

        public async Task<bool> UpdatePasswordAsync(Guid userId, PasswordUpdateDto updateDto)
        {
            var foundUser = await _userRepo.GetByIdAsync(userId);

            if (foundUser == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(updateDto.Password))
            {
                PasswordUtils.HashPassword(
                    updateDto.Password,
                    out string hashedPassword,
                    out byte[] salt
                );
                foundUser.Password = hashedPassword;
                foundUser.Salt = salt;
            }

            await _userRepo.UpdateOnAsync(foundUser);

            return true;
        }
    }
}

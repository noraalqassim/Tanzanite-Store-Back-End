using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.Entity;
using src.Repository;
using static src.DTO.AddressDTO;

namespace src.Services.Address
{
    /// <summary>
    /// Services Contain the business logic of your application and interact with entities, repositories, and other services.
    //  Services use DTOs to transfer data between different layers of the application, such as between the controller and the repository.
    /// </summary>
    public class AddressService : IAddressService
    {
        protected readonly AddressRepository _addressRepo;
        protected readonly IMapper _mapper;

        public AddressService(AddressRepository addressRepo, IMapper mapper)
        {
            _addressRepo = addressRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// user id so every address create for user
        /// </summary>

        public async Task<AddressReadDto> CreateOnAsync(Guid userId, AddressCreateDto createDto)
        {
            var address = _mapper.Map<AddressCreateDto, Entity.Address>(createDto);
            address.UserId = userId;
            await _addressRepo.CreateOnAsync(address);

            return _mapper.Map<Entity.Address, AddressReadDto>(address);
        }

        public async Task<List<AddressReadDto>> GetAllAsync()
        {
            var addressList = await _addressRepo.GetAllAsync();
            return _mapper.Map<List<Entity.Address>, List<AddressReadDto>>(addressList);
        }

        public async Task<List<AddressReadDto>> GetByIdAsync(Guid userId)
        {
            var foundAddresses = await _addressRepo.GetListByIdAsync(userId);

            if (foundAddresses == null || foundAddresses.Count == 0)
            {
                return null;
            }

            var addressList = _mapper.Map<List<Entity.Address>, List<AddressReadDto>>(
                foundAddresses
            );

            return addressList;
        }

        public async Task<bool> DeleteOnAsync(Guid addressId)
        {
            var foundAddress = await _addressRepo.GetByIdAsync(addressId);
            bool isDeleted = await _addressRepo.DeleteOnAsync(foundAddress);
            return isDeleted;
        }

        public async Task<AddressReadDto> UpdateOnAsync(Guid userId, AddressUpdateDto updateDto)
        {
            var foundAddress = await _addressRepo.GetByIdAsync(updateDto.AddressId);

            if (foundAddress == null)
            {
                return null;
            }

            // Update the address details
            foundAddress.Street = updateDto.Street;
            foundAddress.City = updateDto.City;
            foundAddress.County = updateDto.County;
            foundAddress.ZipCode = updateDto.ZipCode;

            await _addressRepo.UpdateOnAsync(foundAddress);

            return _mapper.Map<Entity.Address, AddressReadDto>(foundAddress);
        }
    }
}

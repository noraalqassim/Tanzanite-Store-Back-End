using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        public async Task<AddressReadDto> CreateOnAsync(AddressCreateDto createDto)
        {
            var address = _mapper.Map<AddressCreateDto, src.Entity.Address>(createDto);
            var addressCreated = await _addressRepo.CreateOnAsync(address);
            return _mapper.Map<src.Entity.Address, AddressReadDto>(addressCreated);
        }

        public async Task<List<AddressReadDto>> GetAllAsync()
        {
            var addressList = await _addressRepo.GetAllAsync();
            return _mapper.Map<List<src.Entity.Address>, List<AddressReadDto>>(addressList);
        }

        public async Task<AddressReadDto> GetByIdAsync(Guid AddressId)
        {
            var foundAddress = await _addressRepo.GetByIdAsync(AddressId);
            return _mapper.Map<src.Entity.Address, AddressReadDto>(foundAddress);
        }

        public async Task<bool> DeleteOnAsync(Guid AddressId)
        {
            var foundAddress = await _addressRepo.GetByIdAsync(AddressId);
            bool isDeleted = await _addressRepo.DeleteOnAsync(foundAddress);
            return isDeleted;
        }

        public async Task<bool> UpdateOnAsync(Guid AddressId, AddressUpdateDto updateDto)
        {
            var foundAddress = await _addressRepo.GetByIdAsync(AddressId);

            if (foundAddress == null)
            {
                return false;
            }
            _mapper.Map(updateDto, foundAddress);
            return await _addressRepo.UpdateOnAsync(foundAddress);
        }
    }
}

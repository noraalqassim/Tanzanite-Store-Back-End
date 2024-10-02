using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static src.DTO.AddressDTO;

namespace src.Services.Address
{
    public interface IAddressService
    {
        Task<AddressReadDto> CreateOnAsync(Guid userId, AddressCreateDto createDto);

        Task<List<AddressReadDto>> GetAllAsync();

        Task<List<AddressReadDto>> GetByIdAsync(Guid userId);

        Task<bool> DeleteOnAsync(Guid addressId);

        Task<AddressReadDto> UpdateOnAsync(Guid addressId, AddressUpdateDto updateDto);
    }
}

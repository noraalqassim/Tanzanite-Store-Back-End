using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static src.DTO.AddressDTO;

namespace src.Services.Address
{
    public interface IAddressService
    {
        Task<AddressReadDto> CreateOnAsync(AddressCreateDto createDto);

        Task<List<AddressReadDto>> GetAllAsync();

        Task<AddressReadDto> GetByIdAsync(Guid addressId);

        Task<bool> DeleteOnAsync(Guid addressId);

        Task<bool> UpdateOnAsync(Guid addressId, AddressUpdateDto updateDto);
    }
}

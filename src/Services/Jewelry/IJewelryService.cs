using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static src.DTO.JewelryDTO;

namespace src.Services.Jewelry
{
    public interface IJewelryService
    {
        Task<JewelryReadDto> CreateOneAsync(JewelryCreateDto createDto);
        Task<List<JewelryReadDto>> GetAllAsync(); //get all
        Task<JewelryReadDto> GetByIdAsync(Guid JewelryId);//get by id
        Task<bool> DeleteOneAsync(Guid JewelryId);
        Task<bool> UpdateOneAsync(Guid JewelryId, JewelryUpdateDto updateDto);

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Utils;
using static src.DTO.JewelryDTO;

namespace src.Services.Jewelry
{
    public interface IJewelryService
    {
        Task<JewelryReadDto> CreateOneAsync(JewelryCreateDto createDto);
        Task<List<JewelryReadDto>> GetAllAsync();
        Task<JewelryReadDto> GetByIdAsync(Guid JewelryId);
        Task<bool> UpdateOneAsync(Guid JewelryId, JewelryUpdateDto updateDto);
        Task<bool> DeleteOneAsync(Guid JewelryId);
        Task<List<JewelryReadDto>> GetAllwithPaginationAsync(PaginationOptions paginationOptions);
        Task<int> CountJewelryAsync();
        Task<List<JewelryReadDto>> GetAllByFilterationAsync(FilterationOptions jewelryFilter, PaginationOptions paginationOptions);

    }
}

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
        Task<List<JewelryReadDto>> GetAllAsync(); //get all
        Task<JewelryReadDto> GetByIdAsync(Guid JewelryId);//get by id
        Task<bool> UpdateOneAsync(Guid JewelryId, JewelryUpdateDto updateDto);
        Task<bool> DeleteOneAsync(Guid JewelryId);
        Task<List<JewelryReadDto>> GetByNameAsync(string jewelrySearch); //jewelry searsh by name

        Task<List<JewelryReadDto>> GetAllBySearchAsync(PaginationOptions paginationOptions); //jewelry Search with pagination

        Task<List<JewelryReadDto>> GetAllByFilterationAsync(FilterationOptions jewelryFilter); //jewelry Filters


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static src.DTO.GemstonesDTO;

namespace src.Services.Gemstone
{
    public interface IGemstoneService
    {
        Task<GemstoneReadDto> CreateOneAsync(GemstoneCreateDto createDto);
        Task<List<GemstoneReadDto>> GetAllAsync(); //get all
        Task<GemstoneReadDto> GetByIdAsync(Guid GemstoneId);//get by id
        Task<bool> DeleteOneAsync(Guid GemstoneId);
        Task<bool> UpdateOneAsync(Guid GemstoneId, GemstoneUpdateDto updateDto);

    }
}
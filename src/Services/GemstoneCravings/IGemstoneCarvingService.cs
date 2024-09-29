using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static src.DTO.GemstoneCarvingsDTO;

namespace src.Services.GemstoneCravings
{
    public interface IGemstoneCarvingService
    {
        Task<GemstoneCarvingReadDto> CreateOneAsync(GemstoneCarvingCreateDto createDto);
        Task<List<GemstoneCarvingReadDto>> GetAllAsync(); //get all
        Task<GemstoneCarvingReadDto> GetByIdAsync(Guid CarvingId);//get by id
        Task<bool> DeleteOneAsync(Guid CarvingId);
        Task<bool> UpdateOneAsync(Guid CarvingId, GemstoneCarvingUpdateDto updateDto);

    }
}
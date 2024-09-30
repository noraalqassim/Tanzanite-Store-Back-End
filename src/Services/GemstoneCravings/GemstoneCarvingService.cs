using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.Entity;
using src.Repository;
using src.Services.GemstoneCravings;
using static src.DTO.GemstoneCarvingsDTO;

namespace src.Services.GemstoneCravings
{
    /// <summary>
    /// Services Contain the business logic of your application and interact with entities, repositories, and other services.
    //  Services use DTOs to transfer data between different layers of the application, such as between the controller and the repository.
    /// </summary>
    public class GemstoneCarvingService : IGemstoneCarvingService
    {
        private readonly GemstonesCarvingsRepository _gemstonesCarvingsRepo;
        protected readonly IMapper _mapper;

        public GemstoneCarvingService(GemstonesCarvingsRepository gemstonesCarvingsRepo, IMapper mapper)
        {
            _gemstonesCarvingsRepo = gemstonesCarvingsRepo;
            _mapper = mapper;
        }

        // Create a new gemstone carving
        public async Task<GemstoneCarvingReadDto> CreateOneAsync(GemstoneCarvingCreateDto createDto)
        {
            var carving = _mapper.Map<GemstoneCarvingCreateDto, Gemstones_Carvings>(createDto);
            var createdCarving = await _gemstonesCarvingsRepo.CreateOnAsync(carving);
            return _mapper.Map<src.Entity.Gemstones_Carvings, GemstoneCarvingReadDto>(createdCarving);
        }

        // Get all gemstone carvings
        public async Task<List<GemstoneCarvingReadDto>> GetAllAsync()
        {
            var carvings = await _gemstonesCarvingsRepo.GetAllAsync();
            return _mapper.Map<List<src.Entity.Gemstones_Carvings>, List<GemstoneCarvingReadDto>>(carvings);
        }

        // Get a gemstone carving by its ID
        public async Task<GemstoneCarvingReadDto> GetByIdAsync(Guid carvingId)
        {
            var foundCarving = await _gemstonesCarvingsRepo.GetByIdAsync(carvingId);
            return _mapper.Map<src.Entity.Gemstones_Carvings, GemstoneCarvingReadDto>(foundCarving);
        }

        // Delete a gemstone carving by its ID
        public async Task<bool> DeleteOneAsync(Guid carvingId)
        {
            var foundCarving = await _gemstonesCarvingsRepo.GetByIdAsync(carvingId);
            bool isDeleted = await _gemstonesCarvingsRepo.DeleteOnAsync(foundCarving);
            if (isDeleted)
            {
                return true; // Return false if the carving is not found
            }
            return false;
        }

        // Update a gemstone carving
        public async Task<bool> UpdateOneAsync(Guid carvingId, GemstoneCarvingUpdateDto updateDto)
        {
            var foundCarving = await _gemstonesCarvingsRepo.GetByIdAsync(carvingId);

            if (foundCarving == null)
            {
                return false; // Return false if the carving is not found
            }

            _mapper.Map(updateDto, foundCarving);
            return await _gemstonesCarvingsRepo.UpdateOnAsync(foundCarving);
        }

    }
}
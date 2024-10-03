using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.Entity;
using src.Repository;
using src.Utils;
using static src.DTO.GemstonesDTO;


namespace src.Services.Gemstone
{
    public class GemstoneService : IGemstoneService
    {
        private readonly GemstonesRepository _gemstonesRepo;
        protected readonly IMapper _mapper;

        public GemstoneService(GemstonesRepository gemstonesRepo, IMapper mapper)
        {
            _gemstonesRepo = gemstonesRepo;
            _mapper = mapper;
        }

        // Create a new gemstone 
        public async Task<GemstoneReadDto> CreateOneAsync(GemstoneCreateDto createDto)
        {
            var GemstoneItem = _mapper.Map<GemstoneCreateDto, src.Entity.Gemstones>(createDto);
            var createdGemstone = await _gemstonesRepo.CreateOnAsync(GemstoneItem);
            return _mapper.Map<src.Entity.Gemstones, GemstoneReadDto>(createdGemstone);
        }

        // Get all gemstone 
        public async Task<List<GemstoneReadDto>> GetAllAsync()
        {
            var Gemstones = await _gemstonesRepo.GetAllAsync();
            return _mapper.Map<List<src.Entity.Gemstones>, List<GemstoneReadDto>>(Gemstones);
        }

        // Get a gemstone  by its ID
        public async Task<GemstoneReadDto> GetByIdAsync(Guid GemstoneId)
        {
            var foundGemstone = await _gemstonesRepo.GetByIdAsync(GemstoneId);
            if (foundGemstone == null)
            {
                throw CustomException.NotFound($"category with {GemstoneId} cant find");
            }
            return _mapper.Map<src.Entity.Gemstones, GemstoneReadDto>(foundGemstone);
        }

        // Delete a gemstone  by its ID
        public async Task<bool> DeleteOneAsync(Guid GemstoneId)
        {
            var foundGemstone = await _gemstonesRepo.GetByIdAsync(GemstoneId);
            bool isDeleted = await _gemstonesRepo.DeleteOnAsync(foundGemstone);
            return isDeleted;
        }

        // Update a gemstone 
        public async Task<bool> UpdateOneAsync(Guid GemstoneId, GemstoneUpdateDto updateDto)
        {
            var foundGemstone = await _gemstonesRepo.GetByIdAsync(GemstoneId);

            if (foundGemstone == null)
            {
                return false; // Return false if the Gemstone is not found
            }

            _mapper.Map(updateDto, foundGemstone);
            return await _gemstonesRepo.UpdateOnAsync(foundGemstone);
        }

        //Search with pagination
        public async Task<List<GemstoneReadDto>> GetAllBySearchAsync(PaginationOptions paginationOptions)
        {
            var gemstonesList = await _gemstonesRepo.GetAllBySearch(paginationOptions);
            if (gemstonesList.Count == 0)
            {
                throw CustomException.NotFound($"No results found");
            }
            return _mapper.Map<List<src.Entity.Gemstones>, List<GemstoneReadDto>>(gemstonesList);
        }

        public async Task<List<GemstoneReadDto>> GetAllByFilterationAsync(FilterationOptions gemstonesFilter)
        {
            var gemstonesList = await _gemstonesRepo.GetAllByFilteringAsync(gemstonesFilter);

            return _mapper.Map<List<src.Entity.Gemstones>, List<GemstoneReadDto>>(gemstonesList);
        }

    }
}
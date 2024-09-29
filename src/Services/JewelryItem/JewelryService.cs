using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.Entity;
using src.Repository;
using static src.DTO.JewelryDTO;

namespace src.Services.JewelryItem
{
    public class JewelryService : IJewelryService
    {
        private readonly JewelryRepository _jewelryRepo;
        protected readonly IMapper _mapper;

        public JewelryService(JewelryRepository jewelryRepo, IMapper mapper)
        {
            _jewelryRepo = jewelryRepo;
            _mapper = mapper;
        }

        // Create a new Jewelry 
        public async Task<JewelryReadDto> CreateOneAsync(JewelryCreateDto createDto)
        {
            var JewelryItem = _mapper.Map<JewelryCreateDto, src.Entity.Jewelry>(createDto);
            var createdJewelry = await _jewelryRepo.CreateOnAsync(JewelryItem);
            return _mapper.Map<src.Entity.Jewelry, JewelryReadDto>(createdJewelry);
        }

        // Get all Jewelry 
        public async Task<List<JewelryReadDto>> GetAllAsync()
        {
            var jewelryItems = await _jewelryRepo.GetAllAsync();
            return _mapper.Map<List<src.Entity.Jewelry>, List<JewelryReadDto>>(jewelryItems);
        }

        // Get a Jewelry  by its ID
        public async Task<JewelryReadDto> GetByIdAsync(Guid JewelryId)
        {
            var foundJewelry = await _jewelryRepo.GetByIdAsync(JewelryId);
            return _mapper.Map<src.Entity.Jewelry, JewelryReadDto>(foundJewelry);
        }

        // Delete a Jewelry  by its ID
        public async Task<bool> DeleteOneAsync(Guid JewelryId)
        {
            var foundJewelry = await _jewelryRepo.GetByIdAsync(JewelryId);
            bool isDeleted = await _jewelryRepo.DeleteOnAsync(foundJewelry);

            if (isDeleted)
            {
                return true; // Return false if the  is not found
            }

            return false;

        }

        // Update a Jewelry 
        public async Task<bool> UpdateOneAsync(Guid JewelryId, JewelryUpdateDto updateDto)
        {
            var foundJewelry = await _jewelryRepo.GetByIdAsync(JewelryId);

            if (foundJewelry == null)
            {
                return false; // Return false if the Jewelry is not found
            }

            _mapper.Map(updateDto, foundJewelry);
            return await _jewelryRepo.UpdateOnAsync(foundJewelry);
        }

    }
}
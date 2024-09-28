using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static src.DTO.CategoryDTO;

namespace src.Services.category
{
    public interface ICategoryService
    {
        Task<CategoryReadDto> CreateOneAsync(CategoryCreateDto createDto);
        Task<List<CategoryReadDto>> GetAllAsync();
        Task<CategoryReadDto> GetByIdAsync(Guid id);
        Task<bool> DeleteOneAsync(Guid id);
        Task<bool> UpdateOneAsync(Guid id, CategoryUpdateDto updateDto);

    }
}
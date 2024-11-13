using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Utils;
using static src.DTO.CategoryDTO;

namespace src.Services.category
{
    public interface ICategoryService
    {
        Task<CategoryReadDto> CreateOneAsync(CategoryCreateDto createDto);
        Task<List<CategoryReadDto>> GetAllAsync();
        Task<CategoryReadDto> GetById(Guid id);
        Task<bool> DeleteOneAsync(Guid CategoryId);
        Task<bool> UpdateOneAsync(Guid CategoryId, CategoryUpdateDto updateDto);
        Task<List<CategoryReadDto>> GetAllByFilterationAsync(CategoryFilterationOptions categoryFilter, PaginationOptions paginationOptions);

    }
}
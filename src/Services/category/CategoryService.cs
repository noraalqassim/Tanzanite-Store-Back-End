using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.Entity;
using src.Repository;
using src.Utils;
using static src.DTO.CategoryDTO;

namespace src.Services.category
{
    public class CategoryService : ICategoryService
    {
        protected readonly CategoryRepository _categoryRepo;
        protected readonly IMapper _mapper;

        public CategoryService(CategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<CategoryReadDto> CreateOneAsync(CategoryCreateDto createDto)
        {
            var categoryExists = await _categoryRepo.GetByNameAsync(createDto.CategoryName);
            if (string.IsNullOrWhiteSpace(createDto.CategoryName))
            {
                throw new ArgumentException("Category name cannot be empty or whitespace.");
            }
            else if (createDto.CategoryName.All(char.IsDigit))
            {
                throw new ArgumentException("Category name should be a string.");
            }
            else if (categoryExists != null)
            {
                throw new ArgumentException("A category with this name already exists.");
            }
            var category = _mapper.Map<CategoryCreateDto, Category>(createDto);

            var categoryCreated = await _categoryRepo.CreateOneAsync(category);

            return _mapper.Map<Category, CategoryReadDto>(categoryCreated);
        }

        public async Task<List<CategoryReadDto>> GetAllAsync()
        {
            var categoryList = await _categoryRepo.GetAllAsync();
            return _mapper.Map<List<Category>, List<CategoryReadDto>>(categoryList);
        }

        public async Task<CategoryReadDto> GetByIdAsync(Guid id)
        {
            var foundCategory = await _categoryRepo.GetByIdAsync(id);

            return _mapper.Map<Category, CategoryReadDto>(foundCategory);
        }

        public async Task<bool> DeleteOneAsync(Guid id)
        {
            var foundCategory = await _categoryRepo.GetByIdAsync(id);
            bool isDeleted = await _categoryRepo.DeleteOneAsync(foundCategory);

            if (isDeleted)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateOneAsync(Guid id, CategoryUpdateDto updateDto)
        {
            var foundCategory = await _categoryRepo.GetByIdAsync(id);

            if (foundCategory == null)
            {
                return false;
            }

            _mapper.Map(updateDto, foundCategory);
            return await _categoryRepo.UpdateOneAsync(foundCategory);
        }

        public async Task<List<CategoryReadDto>> GetAllByFilterationAsync(
            CategoryFilterationOptions categoryFilter,
            PaginationOptions paginationOptions
        )
        {
            var categoryName = await _categoryRepo.GetAllByFilteringAsync(
                categoryFilter,
                paginationOptions
            );

            categoryName = categoryName
                .Skip(paginationOptions.Offset)
                .Take(paginationOptions.Limit)
                .ToList();

            return _mapper.Map<List<src.Entity.Category>, List<CategoryReadDto>>(categoryName);
        }
    }
}

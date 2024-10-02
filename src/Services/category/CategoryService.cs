using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.Entity;
using src.Repository;
using static src.DTO.CategoryDTO;

namespace src.Services.category
{
    /// <summary>
    /// Services Contain the business logic of your application and interact with entities, repositories, and other services.
    //  Services use DTOs to transfer data between different layers of the application, such as between the controller and the repository.
    /// </summary>
    public class CategoryService : ICategoryService // CategoryService implements from ICategoryService
    {

        // fields
        protected readonly CategoryRepository _categoryRepo;
        protected readonly IMapper _mapper;

        // Constructor for DI (Dependency Injection)
        public CategoryService(CategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        // Create new Category Asynchronously
        /// <summary>
        ///  when create new category the name should not be created already  
        /// </summary>
  
        public async Task<CategoryReadDto> CreateOneAsync(CategoryCreateDto createDto)
        {
            var categoryExists = await _categoryRepo.GetByNameAsync(createDto.CategoryName);
            if (string.IsNullOrWhiteSpace(createDto.CategoryName)) // Check if the category name is empty or consists only whitespace
            {
                throw new ArgumentException("Category name cannot be empty or whitespace.");
            }
            else if (createDto.CategoryName.All(char.IsDigit)) // Check if the category name consists only numbers
            {
                throw new ArgumentException("Category name should be a string.");
            }
            else if (categoryExists != null) // Check if a category with the same name already exists
            {
                throw new ArgumentException("A category with this name already exists.");
            }
            // else 
            var category = _mapper.Map<CategoryCreateDto, Category>(createDto);

            var categoryCreated = await _categoryRepo.CreateOneAsync(category);

            return _mapper.Map<Category, CategoryReadDto>(categoryCreated);
        }

        // Get all categories Asynchronously
        public async Task<List<CategoryReadDto>> GetAllAsync()
        {
            var categoryList = await _categoryRepo.GetAllAsync();
            return _mapper.Map<List<Category>, List<CategoryReadDto>>(categoryList);
        }

        // Get category by Id Asynchronously
        public async Task<CategoryReadDto> GetByIdAsync(Guid id)
        {
            var foundCategory = await _categoryRepo.GetByIdAsync(id);

            // Check if the category was not found
            // if (foundCategory == null)
            // {
            // Throw an exception 
            // throw new Exception($"Category with ID {id} not found.");
            // }

            return _mapper.Map<Category, CategoryReadDto>(foundCategory);
        }

        // Delete cart by Id Asynchronously
        public async Task<bool> DeleteOneAsync(Guid id)
        {

            // find the category id
            var foundCategory = await _categoryRepo.GetByIdAsync(id);
            bool isDeleted = await _categoryRepo.DeleteOneAsync(foundCategory);

            if (isDeleted)
            {
                return true;
            }
            return false;
        }

        // Update category Asynchronously
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

    } // end class 
} // end namespace
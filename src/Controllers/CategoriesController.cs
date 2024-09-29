using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Services.category;
using Microsoft.AspNetCore.Mvc;
using static src.DTO.CategoryDTO;

// Controller:
// Role: Acts as the entry point for handling HTTP requests. 
// It defines endpoints (routes) for clients to interact with the application.

namespace src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    // api/v1/categories
    public class CategoriesController : ControllerBase // CategoriesController inherits from ControllerBase
    {

        // field
        protected readonly ICategoryService _categoryService;

        // Constructor for DI (Dependency Injection)
        public CategoriesController(ICategoryService service)
        {
            _categoryService = service;
        }

        // Create a new category
        [HttpPost]
        public async Task<ActionResult<CategoryReadDto>> CreateOne(CategoryCreateDto createDto)
        {
            var categoryCreated = await _categoryService.CreateOneAsync(createDto);
            return Ok(categoryCreated); // 200 Ok
        }

        // Get all categories
        [HttpGet]
        public async Task<ActionResult<List<CategoryReadDto>>> GetAll()
        {
            var categoryList = await _categoryService.GetAllAsync();
            return Ok(categoryList); // 200 Ok
        }

        // Get category by id
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryReadDto>> GetById(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(category); // 200 OK 
        }


        // Update a category
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryReadDto>> UpdateOne(Guid id, CategoryUpdateDto updateDto)
        {
            var categoryUpdated = await _categoryService.UpdateOneAsync(id, updateDto);
            if (categoryUpdated == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(categoryUpdated); // 200 OK 
        }

        // Delete a category
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOne(Guid id)
        {
            var categoryDeleted = await _categoryService.DeleteOneAsync(id);
            if (categoryDeleted == false)
            {
                return NotFound(); // 404 Not Found
            }
            return NoContent(); // 200 OK 
        }

    } // end class
} // end namespace
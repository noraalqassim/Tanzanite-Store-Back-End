using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Services.category;
using Microsoft.AspNetCore.Mvc;
using static src.DTO.CategoryDTO;
using Microsoft.AspNetCore.Authorization;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    // api/v1/categories
    public class CategoriesController : ControllerBase // CategoriesController inherits from ControllerBase
    {

        /// <summary>
        /// The point of the categories controller is to act as the entry point for handling HTTP requests related to the product categories.
        /// It defines endpoints (routes) for clients to interact with the application.
        /// include: create, read, update and delete (GET, POST, PUT, DELETE).
        /// 1- Creating a new categories to organize products.
        /// 2- Retrieving a list of categories 
        /// 3- Updating category information, such as name
        /// 4- Deleting category
        /// </summary>

        // field
        protected readonly ICategoryService _categoryService;

        // Constructor for DI (Dependency Injection)
        public CategoriesController(ICategoryService service)
        {
            _categoryService = service;
        }

        /// <API>
        /// {
        ///  "categoryName": "string"
        /// }
        /// </API>
        /// return category info

        // Create a new category
        [HttpPost]
        [Authorize(Roles = "Admin")] //--> For admins
        public async Task<ActionResult<CategoryReadDto>> CreateOne(CategoryCreateDto createDto)
        {
            var categoryCreated = await _categoryService.CreateOneAsync(createDto);
            return Ok(categoryCreated); // 200 Ok
        }

        // Update a category
        [HttpPut("{CategoryId}")]
        [Authorize(Roles = "Admin")] //--> For admins
        public async Task<ActionResult<CategoryReadDto>> UpdateOne(Guid CategoryId, CategoryUpdateDto updateDto)
        {
            var categoryUpdated = await _categoryService.UpdateOneAsync(CategoryId, updateDto);
            if (categoryUpdated == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(categoryUpdated); // 200 OK 
        }

        /// <API>
        /// [
        ///  {
        ///    "categoryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///    "categoryName": "string"
        ///   }
        /// ]
        /// </API>
        /// return category info

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

        // Delete a category
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] //--> For admins
        public async Task<ActionResult> DeleteOne(Guid CategoryId)
        {
            var categoryDeleted = await _categoryService.DeleteOneAsync(CategoryId);
            if (categoryDeleted == false)
            {
                return NotFound(); // 404 Not Found
            }
            return NoContent(); // 200 OK 
        }

    } // end class
} // end namespace
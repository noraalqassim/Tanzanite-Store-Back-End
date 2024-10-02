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
        ///  "categoryName": "Category1"
        /// }
        /// </API>
        /// return category info

        // Create a new category
        // http://localhost:5125/api/v1/categories
        [HttpPost]
        [Authorize(Roles = "Admin")] //--> For admins
        public async Task<ActionResult<CategoryReadDto>> CreateOne(CategoryCreateDto createDto)
        {
            var categoryCreated = await _categoryService.CreateOneAsync(createDto);
            return Ok(categoryCreated); // 200 Ok
        }

        /// <API>
        /// {
        ///  "categoryName": "Category1"
        /// }
        /// </API>
        /// return category info

        // Create a new category
        // http://localhost:5125/api/v1/categories
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")] //--> For admins
        public async Task<ActionResult<CategoryReadDto>> UpdateOne(Guid id, CategoryUpdateDto updateDto)
        {
            var categoryUpdated = await _categoryService.UpdateOneAsync(id, updateDto);
            if (categoryUpdated == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(categoryUpdated); // 200 OK 
        }

        /// <API>
        /// {
        ///  "categoryName": "Category2"
        /// }
        /// </API>
        /// return category info

        // http://localhost:5125/api/v1/categories
        // Get all categories
        [HttpGet]
        public async Task<ActionResult<List<CategoryReadDto>>> GetAll()
        {
            var categoryList = await _categoryService.GetAllAsync();
            return Ok(categoryList); // 200 Ok
        }

        // http://localhost:5125/api/v1/categories/178b89cf-fa2d-4bfb-b4b2-9e828df0ea9d
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

        // http://localhost:5125/api/v1/categories/10940f21-96cc-4c94-ba5d-5afe5d767c98
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
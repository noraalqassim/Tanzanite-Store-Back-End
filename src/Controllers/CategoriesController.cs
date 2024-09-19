using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Entity;

namespace src.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]

    public class CategoriesController : ControllerBase
    {
        // field
        // in-memory database
        public static List<Category> categories = new List<Category>
          {
             new Category { Category_Id = 1, Category_Name = "Ruby" },
             new Category { Category_Id = 2, Category_Name = "Emerald" },
             new Category { Category_Id = 3, Category_Name = "Sapphire" },
             new Category { Category_Id = 4, Category_Name = "Morganite" },
             new Category { Category_Id = 5, Category_Name = "Aquamarine" }
         };

        // ----- GET ----- 

        // base endpoint: http://localhost:5125/api/v1/categories
        [HttpGet]
        public ActionResult GetCategory() // ActionResult: class - return type of http method
        {
            return Ok(categories); // 200
        }

        // get by id
        // base endpoint: http://localhost:5125/api/v1/categories/id/1
        [HttpGet("id/{id}")]
        public ActionResult GetCategoryById(int id)
        {
            Category? foundCategory = categories.FirstOrDefault(p => p.Category_Id == id);
            if (foundCategory == null)
            {
                return NotFound(); // 404
            }
            return Ok(foundCategory); // 200
        }
        // get by name
        // base endpoint: http://localhost:5125/api/v1/categories/name/ruby
        [HttpGet("name/{name}")]
        public ActionResult GetCategoryByName(string name)
        {
            Category? foundCategory = categories.FirstOrDefault(p => p.Category_Name.ToLower() == name.ToLower()); // so when i write Laptop, laptop, LAPTOP, all works the same
            if (foundCategory == null)
            {
                return NotFound(); // 404
            }
            return Ok(foundCategory); // 200
        }

        // ----- POST ----- 

        // base endpoint: http://localhost:5125/api/v1/categories
        [HttpPost]
        public ActionResult CreateCategory(Category newCategory)
        {
            categories.Add(newCategory);
            return CreatedAtAction(nameof(GetCategoryById), new { id = newCategory.Category_Id }, newCategory); // 201
        }

        // ----- DELETE ----- 

        // base endpoint: http://localhost:5125/api/v1/categories/1
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            Category? foundCategory = categories.FirstOrDefault(p => p.Category_Id == id);
            if (foundCategory == null)
            {
                return NotFound(); // 404
            }
            categories.Remove(foundCategory);
            return NoContent(); // 204
        }

        // base endpoint: http://localhost:5125/api/v1/categories/name/Aquamarine
        [HttpDelete("name/{name}")]
        public ActionResult DeleteCategoryByName(string name)
        {
            Category? foundCategory = categories.FirstOrDefault(p => p.Category_Name.ToLower() == name.ToLower()); // so when i write Laptop, laptop, LAPTOP, all works the same
            if (foundCategory == null)
            {
                return NotFound(); // 404
            }
            categories.Remove(foundCategory);
            return NoContent(); // 204
        }

        // ----- PUT ----- 

        // base endpoint: http://localhost:5125/api/v1/categories/1
        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, Category newCategoryInfo)
        {
            Category? foundCategory = categories.FirstOrDefault(p => p.Category_Id == id);
            if (foundCategory == null)
            {
                return NotFound(); // 404
            }
            foundCategory.Category_Name = newCategoryInfo.Category_Name;
            return Ok(foundCategory); // 200
        }

        // base endpoint: http://localhost:5125/api/v1/categories/name/ruby
        [HttpPut("name/{name}")]
        public ActionResult UpdateCategoryByName(string name, Category newCategoryInfo)
        {
            Category? foundCategory = categories.FirstOrDefault(p => p.Category_Name.ToLower() == name.ToLower()); // so when i write Laptop, laptop, LAPTOP, all works the same
            if (foundCategory == null)
            {
                return NotFound(); // 404
            }
            foundCategory.Category_Name = newCategoryInfo.Category_Name;
            return Ok(foundCategory); // 200
        }

    }
}
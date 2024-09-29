using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// DTO (Data Transfer Object):
// Role: Used to transfer data between layers of the application, 
// typically between the controller and service.

namespace src.DTO
{
    public class CategoryDTO
    {
        // create category
        public class CategoryCreateDto
        {
            public string CategoryName { get; set; }

        }

        // read data = get data
        public class CategoryReadDto
        {
            public Guid CategoryId { get; set; }
            public string CategoryName { get; set; }

        }

        // update
        public class CategoryUpdateDto
        {
            public string CategoryName { get; set; }

        }

    } // end class
} // end namespace
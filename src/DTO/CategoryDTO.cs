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
            public string Name { get; set; }

        }

        // read data = get data
        public class CategoryReadDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }

        }

        // update
        public class CategoryUpdateDto
        {
            public string Name { get; set; }

        }

    } // end class
} // end namespace
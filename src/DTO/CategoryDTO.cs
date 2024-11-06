using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;


namespace src.DTO
{
    public class CategoryDTO
    {
      
        public class CategoryCreateDto
        {
            public string CategoryName { get; set; }
            public string CategoryImage { get; set; }

        }

        public class CategoryReadDto
        {
            public Guid CategoryId { get; set; }
            public string CategoryName { get; set; }
            public string CategoryImage { get; set; }

        }

        public class CategoryUpdateDto
        {
            public string CategoryName { get; set; }
            public string CategoryImage { get; set; }

        }

        

    } 
} 
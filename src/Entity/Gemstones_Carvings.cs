// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using System.ComponentModel.DataAnnotations;

// namespace src.Entity
// {
//     /// <summary>
//     /// CarvingName: Name of the carving "Gemstone shepe" like (Oval, Heart, Round, pear).
//     /// Weight: Weight of the carving, likely in carats .
//     /// CarvingPrice: is the base price of the carving without considering the gemstone material.
//     /// Users with the role "admin" to add jewelry items after authentication.
//     /// </summary>
//     public class Gemstones_Carvings
//     {
//         [Key]
//         public Guid CarvingId { get; set; }
//         public string CarvingName { get; set; }
//         public decimal Weight { get; set; }
//         public decimal CarvingPrice { get; set; }
//         public string CarvingInfo { get; set; }
//         public string Image { get; set; }

//         //one to many relaitonship
//         public Guid GemstoneId { get; set; } // Foreign key property for the Gemstone entity
//         public Gemstones Gemstone { get; set; } = null!; // Navigation property referencing the Gemstone entity
//     }
// }
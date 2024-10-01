using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static src.DTO.OrderDTO;

namespace src.Services.Order
{
     public interface IOrderRepository
     {       
        
   Task<OrderReadDto> CreateOneAsync(Guid userId, OrderCreateDto createDto);

       
     }
}
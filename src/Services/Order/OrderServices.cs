// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using AutoMapper;
// using src.Entity; // Import the src.Entity namespace
// using src.Repository;
// using static src.DTO.OrderDTO;

// namespace src.Services.Order
// {
//     /// <summary>
//     /// Services Contain the business logic of your application and interact with entities, repositories, and other services.
//     //  Services use DTOs to transfer data between different layers of the application, such as between the controller and the repository.
//     /// </summary>
//     public class OrderService : IOrderService
//     {
//         protected readonly OrderRepository _orderRepo;
//         protected readonly IMapper _mapper;

//         public OrderService(OrderRepository orderRepo, IMapper mapper)
//         {
//             _orderRepo = orderRepo;
//             _mapper = mapper;
//         }

//         public async Task<OrderReadDto> CreateOnAsync(OrderCreateDto createDto)
//         {
//             var order = _mapper.Map<OrderCreateDto, src.Entity.Order>(createDto);
//             var orderCreated = await _orderRepo.CreateOnAsync(order);
//             return _mapper.Map<src.Entity.Order, OrderReadDto>(orderCreated);
//         }

//         public async Task<List<OrderReadDto>> GetAllAsync()
//         {
//             var orderList = await _orderRepo.GetAllAsync();
//             return _mapper.Map<List<src.Entity.Order>, List<OrderReadDto>>(orderList);
//         }

//         public async Task<OrderReadDto> GetByIdAsync(Guid orderId)
//         {
//             var foundOrder = await _orderRepo.GetByIdAsync(orderId);
//             return _mapper.Map<src.Entity.Order, OrderReadDto>(foundOrder);
//         }

//         public async Task<bool> DeleteOnAsync(Guid orderId)
//         {
//             var foundOrder = await _orderRepo.GetByIdAsync(orderId);
//             bool isDeleted = await _orderRepo.DeleteOnAsync(foundOrder);
//             return isDeleted;
//         }

//         public async Task<bool> UpdateOnAsync(Guid orderId, OrderUpdateDto updateDto)
//         {
//             var foundOrder = await _orderRepo.GetByIdAsync(orderId);

//             if (foundOrder == null)
//             {
//                 return false;
//             }
//             _mapper.Map(updateDto, foundOrder);
//             return await _orderRepo.UpdateOnAsync(foundOrder);
//         }
//     }
// }
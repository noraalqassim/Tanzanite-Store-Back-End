using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.DTO;
using src.Entity; // Import the src.Entity namespace
using src.Repository;
using src.Utils;
using static src.DTO.OrderDTO;

namespace src.Services.Order
{
    public class OrderService : IOrderService
    {
        protected readonly OrderRepository _orderRepo;
        protected readonly IMapper _mapper;

        public OrderService(OrderRepository orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }


        public async Task<OrderReadDto> CreateOnAsync(Guid UserId, OrderCreateDto createDto, Guid addressId)
        {
            var order = _mapper.Map<OrderCreateDto, Entity.Order>(createDto);

            // Set UserId and AddressId 
            order.UserId = UserId;
            order.AddressId = addressId;

            await _orderRepo.CreateOnAsync(order);

            return _mapper.Map<Entity.Order, OrderReadDto>(order);
        }

        public async Task<List<OrderReadDto>> GetAllAsync()
        {
            var orderList = await _orderRepo.GetAllAsync();
            return _mapper.Map<List<Entity.Order>, List<OrderReadDto>>(orderList);
        }

        public async Task<List<OrderReadDto>> GetByUserIdAsync(Guid userId)
        {
            var orders = await _orderRepo.GetAllAsync();
            var ordersByUserId = orders.Where(o => o.UserId == userId).ToList();

            return _mapper.Map<List<Entity.Order>, List<OrderReadDto>>(ordersByUserId);
        }

        public async Task<bool> DeleteOneAsync(Guid orderId)
        {
            var foundOrder = await _orderRepo.GetByIdAsync(orderId);

            bool isDeleted = await _orderRepo.DeleteOnAsync(foundOrder);
            return isDeleted;
        }

        public async Task<bool> UpdateOnAsync(Guid orderId, OrderUpdateDto updateDto)
        {
            var foundOrder = await _orderRepo.GetByIdAsync(orderId);


            if (foundOrder == null)
            {
                throw CustomException.NotFound($"Order with ID {orderId} not found for update");
            }

            _mapper.Map(updateDto, foundOrder);

            bool isUpdated = await _orderRepo.UpdateOnAsync(foundOrder);
            return isUpdated;
        }
    }
}

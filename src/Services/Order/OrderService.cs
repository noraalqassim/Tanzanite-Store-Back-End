using static src.DTO.OrderDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.DTO;
using src.Entity; // Import the src.Entity namespace
using src.Repository;

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

        public async Task<OrderReadDto> CreateOnAsync(OrderCreateDto createDto)
        {
            var order = _mapper.Map<OrderCreateDto, Entity.Order>(createDto);
            var orderCreated = await _orderRepo.CreateOnAsync(order);
            return _mapper.Map<Entity.Order, OrderReadDto>(orderCreated);
        }

        public async Task<List<OrderReadDto>> GetAllAsync()
        {
            var orderList = await _orderRepo.GetAllAsync();
            return _mapper.Map<List<Entity.Order>, List<OrderReadDto>>(orderList);
        }

        public async Task<OrderReadDto> GetByIdAsync(Guid orderId)
        {
            var foundOrder = await _orderRepo.GetByIdAsync(orderId);
            return _mapper.Map<Entity.Order, OrderReadDto>(foundOrder);
        }

        public async Task<bool> UpdateOnAsync(Guid orderId, OrderUpdateDto updateDto)
        {
            var foundOrder = await _orderRepo.GetByIdAsync(orderId);

            if (foundOrder == null)
            {
                return false;
            }
            _mapper.Map(updateDto, foundOrder);
            return await _orderRepo.UpdateOnAsync(foundOrder);
        }

        public async Task<bool> DeleteOneAsync(Guid orderId)
        {
            var foundOrder = await _orderRepo.GetByIdAsync(orderId);

            bool isDeleted = await _orderRepo.DeleteOnAsync(foundOrder);
            return isDeleted;
        }
    }
}
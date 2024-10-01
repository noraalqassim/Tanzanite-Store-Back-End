using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using src.Repositories;
using static src.DTO.OrderDTO;
namespace src.Services.Order
{
    /// <summary>
    /// Services Contain the business logic of your application and interact with entities, repositories, and other services.
    //  Services use DTOs to transfer data between different layers of the application, such as between the controller and the repository.
    /// </summary>
    public class OrderService : IOrderService
    {
        protected readonly OrderRepository _orderRepo;
        protected readonly IMapper _mapper;

        public OrderService(OrderRepository orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }

        public async Task<OrderReadDto> CreateOnAsync(Guid userId, OrderCreateDto createDto)
        {
            var order = _mapper.Map<OrderCreateDto, Entity.Order>(createDto);
            order.UserId = userId;
            await _orderRepo.CreateOneAsync(order);
            return _mapper.Map<Entity.Order, OrderReadDto>(order);
        }

        public Task<OrderReadDto> CreateOneAsync(Guid userId, OrderCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Entity.Order>> CreateOrder(Entity.Order order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOnAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderReadDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<Entity.Order>>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<OrderReadDto> GetByIdAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Entity.Order>> GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOnAsync(Guid orderId, OrderUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateOrder(int id, Entity.Order order)
        {
            throw new NotImplementedException();
        }
    }
}
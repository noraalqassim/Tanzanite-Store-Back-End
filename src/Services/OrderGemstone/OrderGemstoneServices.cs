using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.DTO;
using src.Entity; // Import the src.Entity namespace
using src.Repository;
using static src.DTO.OrderGemstoneDTO;

namespace src.Services.OrderGemstone
{
  /// <summary>
  /// Services Contain the business logic of your application and interact with entities, repositories, and other services.
  ///  Services use DTOs to transfer data between different layers of the application, such as between the controller and the repository.
  /// </summary>
  public class OrderGemstoneService : IOrderGemstoneService
  {
    protected readonly OrderGemstoneRepository _orderGemstoneRepo;
    protected readonly IMapper _mapper;

    public OrderGemstoneService(OrderGemstoneRepository orderGemstoneRepo, IMapper mapper)
    {
      _orderGemstoneRepo = orderGemstoneRepo;
      _mapper = mapper;
    }

    public async Task<OrderGemstoneReadDto> CreateOnAsync(OrderGemstoneCreateDto createDto)
    {
      var orderGemstone = _mapper.Map<OrderGemstoneCreateDto, Entity.OrderGemstone>(createDto);
      var orderGemstoneCreated = await _orderGemstoneRepo.CreateOnAsync(orderGemstone);
      return _mapper.Map<Entity.OrderGemstone, OrderGemstoneReadDto>(orderGemstoneCreated);
    }

    public async Task<List<OrderGemstoneReadDto>> GetAllAsync()
    {
      var orderGemstoneList = await _orderGemstoneRepo.GetAllAsync();
      return _mapper.Map<List<Entity.OrderGemstone>, List<OrderGemstoneReadDto>>(orderGemstoneList);
    }

    public async Task<OrderGemstoneReadDto> GetByIdAsync(Guid orderGemstoneId)
    {
      var foundOrderGemstone = await _orderGemstoneRepo.GetByIdAsync(orderGemstoneId);
      return _mapper.Map<Entity.OrderGemstone, OrderGemstoneReadDto>(foundOrderGemstone);
    }

    public async Task<bool> DeleteOnAsync(Guid orderGemstoneId)
    {
      var foundOrderGemstone = await _orderGemstoneRepo.GetByIdAsync(orderGemstoneId);
      bool isDeleted = await _orderGemstoneRepo.DeleteOnAsync(foundOrderGemstone);
      return isDeleted;
    }

    public async Task<bool> UpdateOnAsync(Guid orderGemstoneId, OrderGemstoneUpdateDto updateDto)
    {
      var foundOrderGemstone = await _orderGemstoneRepo.GetByIdAsync(orderGemstoneId);

      if (foundOrderGemstone == null)
      {
        return false;
      }
      _mapper.Map(updateDto, foundOrderGemstone);
      return await _orderGemstoneRepo.UpdateOnAsync(foundOrderGemstone);
    }

  }
}
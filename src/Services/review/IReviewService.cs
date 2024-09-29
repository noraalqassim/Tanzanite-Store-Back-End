using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static src.DTO.ReviewDTO;

namespace src.Services.review
{
    public interface IReviewService
    {
        Task<ReviewReadDTO> CreateOneAsync(ReviewCreateDTO createDto);
        Task<List<ReviewReadDTO>> GetAllAsync();
        Task<ReviewReadDTO> GetByIdAsync(Guid id);
        Task<bool> DeleteOneAsync(Guid id);
        Task<bool> UpdateOneAsync(Guid id, ReviewUpdateDTO updateDto);

    }
}
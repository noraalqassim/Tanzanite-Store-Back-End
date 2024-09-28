using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.Entity;
using src.Repository;
using static src.DTO.ReviewDTO;

// Service:
// Role: Contains the business logic of the application. It bridges the controller and the repository.

namespace src.Services.review
{
    public class ReviewService : IReviewService // ReviewService implements from IReviewService
    {

        // fields
        protected readonly ReviewRepository _reviewRepo;
        protected readonly IMapper _mapper;

        // Constructor for DI (Dependency Injection)
        public ReviewService(ReviewRepository reviewRepo, IMapper mapper)
        {
            _reviewRepo = reviewRepo;
            _mapper = mapper;
        }

        // Create new Review Asynchronously
        public async Task<ReviewReadDTO> CreateOneAsync(ReviewCreateDTO createDto)
        {
            var review = _mapper.Map<ReviewCreateDTO, Review>(createDto);

            var reviewCreated = await _reviewRepo.CreateOneAsync(review);

            return _mapper.Map<Review, ReviewReadDTO>(reviewCreated);

        }

        // Get all reviews Asynchronously
        public async Task<List<ReviewReadDTO>> GetAllAsync()
        {
            var reviewList = await _reviewRepo.GetAllAsync();
            return _mapper.Map<List<Review>, List<ReviewReadDTO>>(reviewList);
        }

        // Get review by Id Asynchronously
        public async Task<ReviewReadDTO> GetByIdAsync(Guid id)
        {
            var foundReview = await _reviewRepo.GetByIdAsync(id);
            // TO DO: handle error
            // throw
            return _mapper.Map<Review, ReviewReadDTO>(foundReview);

        }

        // Delete cart by Id Asynchronously
        public async Task<bool> DeleteOneAsync(Guid id)
        {

            // find the review id
            var foundReview = await _reviewRepo.GetByIdAsync(id);
            bool isDeleted = await _reviewRepo.DeleteOneAsync(foundReview);

            if (isDeleted)
            {
                return true;
            }
            return false;
        }

        // Update review Asynchronously
        public async Task<bool> UpdateOneAsync(Guid id, ReviewUpdateDTO updateDto)
        {
            var foundReview = await _reviewRepo.GetByIdAsync(id);

            if (foundReview == null)
            {
                return false;
            }

            _mapper.Map(updateDto, foundReview);
            return await _reviewRepo.UpdateOneAsync(foundReview);

        }

    } // end class 
} // end namespace
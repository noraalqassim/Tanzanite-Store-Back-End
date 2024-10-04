using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.Entity;
using src.Repository;
using static src.DTO.ReviewDTO;

namespace src.Services.review
{

    public class ReviewService : IReviewService 
    {

        protected readonly ReviewRepository _reviewRepo;
        protected readonly IMapper _mapper;

        public ReviewService(ReviewRepository reviewRepo, IMapper mapper)
        {
            _reviewRepo = reviewRepo;
            _mapper = mapper;
        }

        public async Task<ReviewReadDTO> CreateOneAsync(ReviewCreateDTO createDto)
        {
            var review = _mapper.Map<ReviewCreateDTO, Review>(createDto);

            var reviewCreated = await _reviewRepo.CreateOneAsync(review);

            return _mapper.Map<Review, ReviewReadDTO>(reviewCreated);

        }

        public async Task<List<ReviewReadDTO>> GetAllAsync()
        {
            var reviewList = await _reviewRepo.GetAllAsync();
            return _mapper.Map<List<Review>, List<ReviewReadDTO>>(reviewList);
        }

        public async Task<ReviewReadDTO> GetByIdAsync(Guid id)
        {
            var foundReview = await _reviewRepo.GetByIdAsync(id);
           
            return _mapper.Map<Review, ReviewReadDTO>(foundReview);

        }

        public async Task<bool> DeleteOneAsync(Guid id)
        {

            var foundReview = await _reviewRepo.GetByIdAsync(id);
            bool isDeleted = await _reviewRepo.DeleteOneAsync(foundReview);

            if (isDeleted)
            {
                return true;
            }
            return false;
        }

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

    } 
} 
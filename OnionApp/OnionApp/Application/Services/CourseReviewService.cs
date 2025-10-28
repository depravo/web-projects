using OnionApp.Application.DTO;
using OnionApp.Core.Interfaces;
using OnionApp.Core.Services;
using OnionApp.Infrastructure.Repositories;
using OnionApp.Application.Mappings;

namespace OnionApp.Application.Services {
	public class CourseReviewService : ICourseReviewService {

		private readonly ICourseReviewRepository _courseReviewRepository;

		public CourseReviewService(ICourseReviewRepository courseReviewRepository) {
			_courseReviewRepository = courseReviewRepository;
		}
		public async Task CreateCourseReviewAsync(CourseReviewDto courseReviewDto) {
			var courseReview = CourseReviewMapper.MapToEntity(courseReviewDto);
			await _courseReviewRepository.AddAsync(courseReview);
		}

		public async Task DeleteCourseReviewAsync(int id) {
			await _courseReviewRepository.DeleteAsync(id);
		}

		public async Task<IEnumerable<CourseReviewResponseDto>> GetAllCourseReviewsAsync() {
			var courseReviews = await _courseReviewRepository.GetAllAsync();
			return courseReviews.Select(cr => CourseReviewMapper.MapToResponseDto(cr));
		}

		public async Task<CourseReviewResponseDto> GetCourseReviewByIdAsync(int id) {
			var courseReview = await _courseReviewRepository.GetByIdAsync(id);
			return courseReview == null ? null : CourseReviewMapper.MapToResponseDto(courseReview);
		}

		public async Task UpdateCourseReviewAsync(int id, CourseReviewUpdateDto courseReviewDto) {
			var courseReview = await _courseReviewRepository.GetByIdAsync(id);
			if (courseReview == null)
				throw new KeyNotFoundException($"Course review with ID {id} not found");

			courseReview.Update(courseReviewDto.Rating, courseReviewDto.Comment);
			await _courseReviewRepository.UpdateAsync(courseReview);
		}
	}
}

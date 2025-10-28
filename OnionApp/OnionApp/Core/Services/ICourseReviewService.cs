using OnionApp.Application.DTO;

namespace OnionApp.Core.Services {
	public interface ICourseReviewService {
		Task<CourseReviewResponseDto> GetCourseReviewByIdAsync(int id);
		Task<IEnumerable<CourseReviewResponseDto>> GetAllCourseReviewsAsync();
		Task CreateCourseReviewAsync(CourseReviewDto courseReviewDto);
		Task UpdateCourseReviewAsync(int id, CourseReviewUpdateDto courseReviewDto);
		Task DeleteCourseReviewAsync(int id);
	}
}

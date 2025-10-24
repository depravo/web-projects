using OnionApp.Application.DTO;

namespace OnionApp.Core.Services {
	public interface ICourseService {
		Task<CourseResponseDto> GetCourseByIdAsync(int id);
		Task<IEnumerable<CourseResponseDto>> GetAllCoursesAsync();
		Task CreateCourseAsync(CourseDto courseDto);
		Task UpdateCourseAsync(int id, CourseDto courseDto);
		Task DeleteCourseAsync(int id);
	}
}

using OnionApp.Application.DTO;
using OnionApp.Core.Interfaces;
using OnionApp.Core.Services;
using OnionApp.Application.Mappings;

namespace OnionApp.Application.Services {
	public class CourseService : ICourseService {

		private readonly ICourseRepository _courseRepository;

		public CourseService(ICourseRepository courseRepository) {
			_courseRepository = courseRepository;
		}
		public async Task CreateCourseAsync(CourseDto courseDto) {
			var course = CourseMapper.MapToEntity(courseDto);
			await _courseRepository.AddAsync(course);
		}

		public async Task DeleteCourseAsync(int id) {
			await _courseRepository.DeleteAsync(id);
		}

		public async Task<IEnumerable<CourseResponseDto>> GetAllCoursesAsync() {
			var courses = await _courseRepository.GetAllAsync();
			return courses.Select(c => CourseMapper.MapToResponseDto(c));
		}

		public async Task<CourseResponseDto> GetCourseByIdAsync(int id) {
			var course = await _courseRepository.GetByIdAsync(id);
			return course == null ? null : CourseMapper.MapToResponseDto(course);
		}

		public async Task UpdateCourseAsync(int id, CourseDto courseDto) {
			var course = await _courseRepository.GetByIdAsync(id);
			if (course == null)
				throw new KeyNotFoundException($"Course with ID {id} not found");

			course.Update(courseDto.Title, courseDto.Description, courseDto.Price);
			await _courseRepository.UpdateAsync(course);
		}
	}
}

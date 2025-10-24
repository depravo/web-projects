using OnionApp.Application.DTO;
using OnionApp.Core.Entities;

namespace OnionApp.Application.Mappings {
	public class CourseMapper {
		public static CourseResponseDto MapToResponseDto(Course course) {
			if (course == null) return null;

			return new CourseResponseDto {
				Id = course.Id,
				Title = course.Title,
				Description = course.Description,
				Price = course.Price
			};
		}

		public static Course MapToEntity(CourseDto courseDto) {
			if (courseDto == null) return null;

			return new Course(courseDto.Title, courseDto.Description, courseDto.Price);
		}
	}
}

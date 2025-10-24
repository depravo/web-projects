using OnionApp.Application.DTO;
using OnionApp.Core.Entities;

namespace OnionApp.Application.Mappings {
	public class CourseReviewMapper {
		public static CourseReviewResponseDto MapToResponseDto(CourseReview courseReview) {
			if (courseReview == null) return null;

			return new CourseReviewResponseDto {
				Id = courseReview.Id,
				CourseId = courseReview.CourseId,
				UserId = courseReview.UserId,
				Rating = courseReview.Rating,
				Comment = courseReview.Comment,
				CreatedAt = courseReview.CreatedAt
			};
		}

		public static CourseReview MapToEntity(CourseReviewDto courseReviewDto) {
			if (courseReviewDto == null) return null;

			return new CourseReview(courseReviewDto.UserId, courseReviewDto.CourseId, courseReviewDto.Rating, courseReviewDto.Comment);
		}
	}
}

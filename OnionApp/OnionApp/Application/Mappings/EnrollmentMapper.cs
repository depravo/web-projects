using OnionApp.Application.DTO;
using OnionApp.Core.Entities;

namespace OnionApp.Application.Mappings {
	public class EnrollmentMapper {
		public static EnrollmentResponseDto MapToResponseDto(Enrollment enrollment) {
			if (enrollment == null) return null;

			return new EnrollmentResponseDto {
				Id = enrollment.Id,
				CourseId = enrollment.CourseId,
				UserId = enrollment.UserId,
				EnrolledAt = enrollment.EnrolledAt,
				Grade = enrollment.Grade
			};
		}

		public static Enrollment MapToEntity(EnrollmentDto enrollmentDto) {
			if (enrollmentDto == null) return null;

			return new Enrollment(enrollmentDto.UserId, enrollmentDto.CourseId, enrollmentDto.Grade);
		}
	}
}

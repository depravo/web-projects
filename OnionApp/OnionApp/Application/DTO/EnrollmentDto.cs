using OnionApp.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionApp.Application.DTO {
	public class EnrollmentDto {
		public int UserId { get; set; }
		public int CourseId { get; set; }
		public double Grade { get; set; }
	}
	public class EnrollmentUpdateDto {
		public DateTime EnrolledAt { get; set; }
		public double Grade { get; set; }
	}


	public class EnrollmentResponseDto {
		public int Id { get; set; }
		public int UserId { get; set; }
		public int CourseId { get; set; }
		public DateTime EnrolledAt { get; set; }
		public double Grade { get; set; }
	}
}

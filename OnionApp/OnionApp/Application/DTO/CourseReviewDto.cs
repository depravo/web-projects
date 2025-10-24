using OnionApp.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionApp.Application.DTO {
	public class CourseReviewDto {
		public int UserId { get; set; }
		public int CourseId { get; set; }
		public int Rating { get; set; }
		public string Comment { get; set; }
	}

	public class CourseReviewUpdateDto {
		public int Rating { get; set; }
		public string Comment { get; set; }
	}

	public class CourseReviewResponseDto {
		public int Id { get; set; }
		public int UserId { get; set; }
		public int CourseId { get; set; }
		public int Rating { get; set; }
		public string Comment { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}

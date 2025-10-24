using OnionApp.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnionApp.Application.DTO {
	public class CourseDto {
		public string Title { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
	}

	public class CourseResponseDto {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
	}
}

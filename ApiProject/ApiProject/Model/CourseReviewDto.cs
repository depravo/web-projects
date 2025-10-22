using CreateDBProj;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProject.Model {
	public class CourseReviewDto {
		public int UserId { get; set; }
		public int CourseId { get; set; }

		public int Rating { get; set; }
		public string Comment { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}

}

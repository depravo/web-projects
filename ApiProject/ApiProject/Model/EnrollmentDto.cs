using CreateDBProj;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProject.Model {
	public class EnrollmentDto {
		public int UserId { get; set; }

		public int CourseId { get; set; }

		public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
		public double? Grade { get; set; }
	}
}

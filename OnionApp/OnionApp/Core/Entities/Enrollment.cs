using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionApp.Core.Entities {
	public class Enrollment {
		[Key]
		public int Id { get; set; }
		public int UserId { get; set; }

		[ForeignKey("UserId")]
		public User? User { get; set; }
		public int CourseId { get; set; }

		[ForeignKey("CourseId")]
		public Course? Course { get; set; }
		public DateTime EnrolledAt { get; set; }
		public double Grade { get; set; }
		public Enrollment(int userId, int courseId, double grade) {
			UserId = userId;
			CourseId = courseId;
			EnrolledAt = DateTime.UtcNow;
			Grade = grade;
		}

		public void Update(DateTime EnrolledAt, double Grade) {
			this.EnrolledAt = EnrolledAt;
			this.Grade = Grade;
		}
	}
}

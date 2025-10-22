using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDBProj {
	public class CourseReview {
		public CourseReview(int userId, int courseId, int rating, string comment, DateTime createdAt) {
			UserId = userId;
			CourseId = courseId;
			Rating = rating;
			Comment = comment;
			CreatedAt = createdAt;
		}

		[Key]
		public int Id { get; set; }
		public int UserId { get; set; }

		[ForeignKey("UserId")]
		public User? User { get; set; }	
		public int CourseId { get; set; }

		[ForeignKey("CourseId")]
		public Course? Course { get; set; }
		[Range(1, 5)]
		public int Rating { get; set; }
		public string Comment { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}

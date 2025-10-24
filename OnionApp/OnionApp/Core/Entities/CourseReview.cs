using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionApp.Core.Entities {
	public class CourseReview {
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
		public DateTime CreatedAt { get; set; }
		public CourseReview(int userId, int courseId, int rating, string comment) {
			UserId = userId;
			CourseId = courseId;
			Rating = rating;
			Comment = comment;
			CreatedAt = DateTime.UtcNow;
		}

		public void Update(int Rating, string Comment) {
			this.Rating = Rating;
			this.Comment = Comment;
		}
	}
}

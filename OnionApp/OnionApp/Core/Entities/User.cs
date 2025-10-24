using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionApp.Core.Entities {
	public class User {
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(100)]
		public string FirstName { get; set; }
		[Required]
		[MaxLength(100)]
		public string LastName { get; set; }
		[Required]
		[MaxLength(100)]
		[EmailAddress]
		public string Email { get; set; }
		public DateTime RegisteredAt { get; set; }
		public IEnumerable<CourseReview> courseReviews { get; set; } = new List<CourseReview>();
		public IEnumerable<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

		public User(string firstName, string lastName, string email) {
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Email = email;
			this.RegisteredAt = DateTime.UtcNow;
		}

		public void Update(string firstName, string lastName, string email) {
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Email = email;
		}
	}
}

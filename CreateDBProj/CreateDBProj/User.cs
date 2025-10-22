using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDBProj {
	public class User {
		public User(string firstName, string lastName, string email) {
			FirstName = firstName;
			LastName = lastName;
			Email = email;
		}

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
		public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
		public IEnumerable<CourseReview> courseReviews { get; set; } = new List<CourseReview>();
		public IEnumerable<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

		[NotMapped]
		public string FullName => $"{FirstName} {LastName}";
	}
}

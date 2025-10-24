using System.ComponentModel.DataAnnotations;

namespace OnionApp.Core.Entities {
	public class Course {
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string Title { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public ICollection<CourseReview> CourseReviews { get; set; } = new List<CourseReview>();
		public ICollection<Module> Modules { get; set; } = new List<Module>();
		public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

		public Course(string Title, string Description, double Price) {
			this.Title = Title;
			this.Description = Description;
			this.Price = Price;
		}

		public void Update(string Title, string Description, double Price) {
			this.Title = Title;
			this.Description = Description;
			this.Price = Price;
		}
	}
}

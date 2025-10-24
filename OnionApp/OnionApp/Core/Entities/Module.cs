using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionApp.Core.Entities {
	public class Module {
		[Key]
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		public int OrderNumber { get; set; }
		public int CourseId { get; set; }

		[ForeignKey("CourseId")]
		public Course? Course { get; set; }
		public Module(string Title, int OrderNumber, int CourseId) {
			this.Title = Title;
			this.OrderNumber = OrderNumber;
			this.CourseId = CourseId;
		}

		public void Update(string Title, int OrderNumber) {
			this.Title = Title;
			this.OrderNumber = OrderNumber;
		}
	}
}

using CreateDBProj;
using System.ComponentModel.DataAnnotations;

namespace ApiProject.Model {
	public class CourseDto {
		public string Title { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
	}
}

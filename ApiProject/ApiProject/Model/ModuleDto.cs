using CreateDBProj;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProject.Model {
	public class ModuleDto {
		public string Title { get; set; }
		public int OrderNumber { get; set; }
		public int CourseId { get; set; }
	}
}

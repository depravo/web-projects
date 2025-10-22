using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CreateDBProj {
	public class Module {

		public Module(string Title, int OrderNumber, int CourseId) {
			this.Title = Title;
			this.OrderNumber = OrderNumber;
			this.CourseId = CourseId;
		}
		[Key]
		public int Id { get; set; }
		
		[Required]
		public string Title { get; set; }
		public int OrderNumber {  get; set; }
		public int CourseId { get; set; }

		[ForeignKey("CourseId")]
		public Course? Course { get; set; }
	}
}

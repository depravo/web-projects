namespace OnionApp.Application.DTO {
	public class ModuleDto {
		public string Title { get; set; }
		public int OrderNumber { get; set; }
		public int CourseId { get; set; }
	}

	public class ModuleUpdateDto { 
		public string Title { get; set; }
		public int OrderNumber { get; set; }
	}

	public class ModuleResponseDto {
		public int Id { get; set; }
		public string Title { get; set; }
		public int OrderNumber { get; set; }
	}
}

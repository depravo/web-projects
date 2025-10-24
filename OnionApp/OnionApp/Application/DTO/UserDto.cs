namespace OnionApp.Application.DTO {
	public class UserDto {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
	}

	public class UserResponseDto {
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public DateTime RegisteredAt { get; set; }
	}
}

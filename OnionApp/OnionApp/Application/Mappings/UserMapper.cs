using OnionApp.Application.DTO;
using OnionApp.Core.Entities;

namespace OnionApp.Application.Mappings {
	public class UserMapper {
		public static UserResponseDto MapToResponseDto(User user) {
			if (user == null) return null;

			return new UserResponseDto {
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				RegisteredAt = user.RegisteredAt
			};
		}

		public static User MapToEntity(UserDto userDto) {
			if (userDto == null) return null;

			return new User(userDto.FirstName, userDto.LastName, userDto.Email);
		}
	}
}

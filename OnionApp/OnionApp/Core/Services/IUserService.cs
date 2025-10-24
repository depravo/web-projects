using OnionApp.Application.DTO;

namespace OnionApp.Core.Services {
	public interface IUserService {
		Task<UserResponseDto> GetUserByIdAsync(int id);
		Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
		Task CreateUserAsync(UserDto userDto);
		Task UpdateUserAsync(int id, UserDto userDto);
		Task DeleteUserAsync(int id);
	}
}

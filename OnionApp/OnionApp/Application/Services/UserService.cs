using OnionApp.Application.DTO;
using OnionApp.Core.Interfaces;
using OnionApp.Core.Services;
using OnionApp.Application.Mappings;
using OnionApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace OnionApp.Application.Services {
	public class UserService : IUserService {

		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository) {
			_userRepository = userRepository;
		}
		public async Task CreateUserAsync(UserDto userDto) {
			var user = UserMapper.MapToEntity(userDto);
			await _userRepository.AddAsync(user);
		}

		public async Task DeleteUserAsync(int id) {
			await _userRepository.DeleteAsync(id);
		}

		public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync() {
			var users = await _userRepository.GetAllAsync();
			return users.Select(u => UserMapper.MapToResponseDto(u));
		}

		public async Task<UserResponseDto> GetUserByIdAsync(int id) {
			var user = await _userRepository.GetByIdAsync(id);
			return user == null ? null : UserMapper.MapToResponseDto(user);
		}

		public async Task UpdateUserAsync(int id, UserDto userDto) {
			var user = await _userRepository.GetByIdAsync(id);
			if (user == null)
				throw new KeyNotFoundException($"User with ID {id} not found");

			user.Update(userDto.FirstName, userDto.LastName, userDto.Email);
			await _userRepository.UpdateAsync(user);
		}
	}
}

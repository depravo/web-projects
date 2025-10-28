using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.DTO;
using OnionApp.Core.Services;

namespace OnionApp.Presentation.Controllers {
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase {
		private readonly IUserService _userService;

		public UsersController(IUserService userService) {
			_userService = userService;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAllUsers() {
			var users = await _userService.GetAllUsersAsync();
			return Ok(users);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetUser(int id) {
			var user = await _userService.GetUserByIdAsync(id);
			if (user == null)
				return NotFound();

			return Ok(user);
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateUser([FromBody] UserDto request) {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try {
				await _userService.CreateUserAsync(request);
				return Created();
			} catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("edit/{id}")]
		public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto request) {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try {
				await _userService.UpdateUserAsync(id, request);
				return Ok();
			} catch (KeyNotFoundException) {
				return NotFound();
			} catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteUser(int id) {
			try {
				await _userService.DeleteUserAsync(id);
				return Ok();
			} catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}
	}
}

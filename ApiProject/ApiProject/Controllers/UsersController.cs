using ApiProject.Model;
using CreateDBProj;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase {
		private readonly ApplicationContext _context;

		public UsersController(ApplicationContext context) {
			_context = context;
		}

		// GET: Users/all
		[HttpGet("all")]
		public IActionResult Index() {
			var res = new List<User>();
			try {
				res = _context.Users.ToList();
			} catch (Exception e) {
				NotFound(e.Message);
			}
			return Ok(res);
		}

		// GET: Users/{id}
		[HttpGet("{id}")]
		public IActionResult Details(int? id) {
			if (id == null) {
				return NotFound();
			}

			var user = _context.Users
				.FirstOrDefault(m => m.Id == id);
			if (user == null) {
				return NotFound();
			}

			return Ok(user);
		}

		// POST: Users/Create
		[HttpPost("create")]
		public IActionResult Create([FromBody] UserDto request) {
			if (request != null) {
				var user = new User(request.firstName, request.lastName, request.email);
				_context.Add(user);
				_context.SaveChanges();
				return Created();
			}
			return BadRequest();
		}

		// POST: Users/Edit/5
		[HttpPost("edit/{id}")]
		public IActionResult Edit(int id, [FromBody] UserDto request) {
			var user = _context.Users.Find(id);
			if (user == null) {
				return NotFound($"User with ID {id} not found");
			}
			if (!string.IsNullOrEmpty(request.firstName))
				user.FirstName = request.firstName;

			if (!string.IsNullOrEmpty(request.lastName))
				user.LastName = request.lastName;

			if (!string.IsNullOrEmpty(request.email))
				user.Email = request.email;

			try {
				_context.Update(user);
				_context.SaveChanges();
				return Ok();
			} catch (DbUpdateConcurrencyException) {
				return Conflict("The user was modified by another process");
			} catch (Exception ex) {
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		// DELETE: Users/Delete/5
		[HttpDelete("delete/{id}")]
		public IActionResult Delete(int id) {
			var user = _context.Users.Find(id);
			if (user != null) {
				_context.Users.Remove(user);
				_context.SaveChanges();
				return Ok();
			}
			return BadRequest();
		}
	}
}

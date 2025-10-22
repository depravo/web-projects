using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CreateDBProj;
using ApiProject.Model;

namespace ApiProject.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CoursesController : ControllerBase {
		private readonly ApplicationContext _context;

		public CoursesController(ApplicationContext context) {
			_context = context;
		}

		// GET: Courses/all
		[HttpGet("all")]
		public IActionResult Index() {
			var res = new List<Course>();
			try {
				res = _context.Courses.ToList();

			} catch (Exception e) {
				NotFound(e.Message);
			}
			return Ok(res);
		}

		// GET: Courses/Details/5
		[HttpGet("{id}")]
		public IActionResult Details(int? id) {
			if (id == null) {
				return NotFound();
			}

			var course = _context.Courses
				.FirstOrDefault(m => m.Id == id);
			if (course == null) {
				return NotFound();
			}

			return Ok(course);
		}

		// GET: Courses/Create
		[HttpPost("create")]
		public IActionResult Create([FromBody] CourseDto request) {
			if (request != null) {
				var course = new Course(request.Title, request.Description, request.Price);
				_context.Add(course);
				_context.SaveChanges();
				return Created();
			}
			return BadRequest();
		}

		// GET: Courses/Edit/5
		[HttpPost("edit/{id}")]
		public IActionResult Edit(int? id, [FromBody] CourseDto request) {
			var course = _context.Courses.Find(id);
			if (course == null) {
				return NotFound($"User with ID {id} not found");
			}
			if (!string.IsNullOrEmpty(request.Title))
				course.Title = request.Title;

			if (!string.IsNullOrEmpty(request.Description))
				course.Description = request.Description;

			if (request.Price != null)
				course.Price = request.Price;

			try {
				_context.Update(course);
				_context.SaveChanges();
				return Ok();
			} catch (DbUpdateConcurrencyException) {
				return Conflict("The user was modified by another process");
			} catch (Exception ex) {
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		// GET: Courses/Delete/5
		[HttpDelete("delete/{id}")]
		public IActionResult Delete(int? id) {
			var course = _context.Courses.Find(id);
			if (course != null) {
				_context.Courses.Remove(course);
				_context.SaveChanges();
				return Ok();
			}
			return BadRequest();
		}
	}
}

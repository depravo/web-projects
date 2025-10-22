using ApiProject.Model;
using CreateDBProj;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class EnrollmentsController : ControllerBase {
		private readonly ApplicationContext _context;

		public EnrollmentsController(ApplicationContext context) {
			_context = context;
		}

		// GET: Enrollments/all
		[HttpGet("all")]
		public IActionResult Index() {
			var res = new List<Enrollment>();
			try {
				res = _context.Enrollments.ToList();
			} catch (Exception e) {
				NotFound(e.Message);
			}
			return Ok(res);
		}

		// GET: Enrollments/{id}
		[HttpGet("{id}")]
		public IActionResult Details(int? id) {
			if (id == null) {
				return NotFound();
			}

			var enrollment = _context.Enrollments
				.FirstOrDefault(m => m.Id == id);
			if (enrollment == null) {
				return NotFound();
			}

			return Ok(enrollment);
		}

		// POST: Enrollments/Create
		[HttpPost("create")]
		public IActionResult Create([FromBody] EnrollmentDto request) {
			if (request != null) {
				var enrollment = new Enrollment(request.UserId, request.CourseId, request.EnrolledAt, request.Grade);
				_context.Add(enrollment);
				_context.SaveChanges();
				return Created();
			}
			return BadRequest();
		}

		// POST: Enrollments/Edit/5
		[HttpPost("edit/{id}")]
		public IActionResult Edit(int id, [FromBody] EnrollmentDto request) {
			var enrollment = _context.Enrollments.Find(id);
			if (enrollment == null) {
				return NotFound($"Enrollment with ID {id} not found");
			}
			enrollment.UserId = request.UserId;

			enrollment.CourseId = request.CourseId;

			enrollment.EnrolledAt = request.EnrolledAt;

			enrollment.Grade = request.Grade;

			try {
				_context.Update(enrollment);
				_context.SaveChanges();
				return Ok();
			} catch (DbUpdateConcurrencyException) {
				return Conflict("The enrollment was modified by another process");
			} catch (Exception ex) {
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		// DELETE: Enrollments/Delete/5
		[HttpDelete("delete/{id}")]
		public IActionResult Delete(int id) {
			var enrollment = _context.Enrollments.Find(id);
			if (enrollment != null) {
				_context.Enrollments.Remove(enrollment);
				_context.SaveChanges();
				return Ok();
			}
			return BadRequest();
		}

	}
}

using ApiProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CreateDBProj;

namespace ApiProject.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CourseReviewsController : ControllerBase {
		private readonly ApplicationContext _context;

		public CourseReviewsController(ApplicationContext context) {
			_context = context;
		}

		// GET: CourseReviews/all
		[HttpGet("all")]
		public IActionResult Index() {
			var res = new List<CourseReview>();
			try {
				res = _context.CourseReviews.ToList();
			} catch (Exception e) {
				NotFound(e.Message);
			}
			return Ok(res);
		}

		// GET: CourseReviews/5
		[HttpGet("{id}")]
		public IActionResult Details(int? id) {
			if (id == null) {
				return NotFound();
			}

			var courseReview = _context.CourseReviews
				.FirstOrDefault(m => m.Id == id);
			if (courseReview == null) {
				return NotFound();
			}

			return Ok(courseReview);
		}

		// GET: CourseReviews/Create
		[HttpPost("create")]
		public IActionResult Create([FromBody] CourseReviewDto request) {
			if (request != null) {
				var courseReview = new CourseReview(request.UserId, request.CourseId, request.Rating, request.Comment, request.CreatedAt);
				_context.Add(courseReview);
				_context.SaveChanges();
				return Created();
			}
			return BadRequest();
		}

		// GET: CourseReviews/Edit/5
		[HttpPost("edit/{id}")]
		public IActionResult Edit(int? id, [FromBody] CourseReviewDto request) {
			var courseReview = _context.CourseReviews.Find(id);
			if (courseReview == null) {
				return NotFound($"Course review with ID {id} not found");
			}
			if (_context.Users.Find(request.UserId) != null) {
				courseReview.UserId = request.UserId;
			} else {
				return BadRequest();
			}

			if (_context.Courses.Find(request.CourseId) != null) {
				courseReview.CourseId = request.CourseId;
			} else {
				return BadRequest();
			}
			courseReview.Rating = request.Rating;

			if (!string.IsNullOrEmpty(request.Comment))
				courseReview.Comment = request.Comment;

			courseReview.CreatedAt = request.CreatedAt;

			_context.Entry(courseReview).Reference(cr => cr.User).CurrentValue = null;
			_context.Entry(courseReview).Reference(cr => cr.Course).CurrentValue = null;
			try {
				_context.Update(courseReview);
				_context.SaveChanges();
				return Ok();
			} catch (DbUpdateConcurrencyException) {
				return Conflict("The courseReview was modified by another process");
			} catch (Exception ex) {
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		// GET: CourseReviews/Delete/5
		[HttpDelete("delete/{id}")]
		public IActionResult Delete(int? id) {
			var courseReview = _context.CourseReviews.Find(id);
			if (courseReview != null) {
				_context.CourseReviews.Remove(courseReview);
				_context.SaveChanges();
				return Ok();
			}
			return BadRequest();
		}
	}
}

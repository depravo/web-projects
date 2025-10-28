using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.DTO;
using OnionApp.Core.Services;

namespace OnionApp.Presentation.Controllers {
	[ApiController]
	[Route("api/[controller]")]
	public class CourseReviewsController : ControllerBase {
		private readonly ICourseReviewService _courseReviewService;

		public CourseReviewsController(ICourseReviewService courseReviewService) {
			_courseReviewService = courseReviewService;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAllCourseReviews() {
			var courseReviews = await _courseReviewService.GetAllCourseReviewsAsync();
			return Ok(courseReviews);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCourseReview(int id) {
			var courseReview = await _courseReviewService.GetCourseReviewByIdAsync(id);
			if (courseReview == null)
				return NotFound();

			return Ok(courseReview);
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateCourseReview([FromBody] CourseReviewDto request) {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try {
				await _courseReviewService.CreateCourseReviewAsync(request);
				return Created();
			} catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("edit/{id}")]
		public async Task<IActionResult> UpdateCourseReview(int id, [FromBody] CourseReviewUpdateDto request) {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try {
				await _courseReviewService.UpdateCourseReviewAsync(id, request);
				return Ok();
			} catch (KeyNotFoundException) {
				return NotFound();
			} catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteCourseReview(int id) {
			try {
				await _courseReviewService.DeleteCourseReviewAsync(id);
				return Ok();
			} catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}
	}
}

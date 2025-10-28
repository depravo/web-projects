using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.DTO;
using OnionApp.Application.Services;
using OnionApp.Core.Services;

namespace OnionApp.Presentation.Controllers {
	[ApiController]
	[Route("api/[controller]")]
	public class CoursesController : ControllerBase {
		private readonly ICourseService _courseService;

		public CoursesController(ICourseService courseService) {
			_courseService = courseService;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAllCourses() {
			var courses = await _courseService.GetAllCoursesAsync();
			return Ok(courses);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCourse(int id) {
			var course = await _courseService.GetCourseByIdAsync(id);
			if (course == null)
				return NotFound();

			return Ok(course);
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateCourse([FromBody] CourseDto request) {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try {
				await _courseService.CreateCourseAsync(request);
				return Created();
			} catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("edit/{id}")]
		public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseDto request) {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try {
				await _courseService.UpdateCourseAsync(id, request);
				return Ok();
			} catch (KeyNotFoundException) {
				return NotFound();
			} catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteCourse(int id) {
			try {
				await _courseService.DeleteCourseAsync(id);
				return Ok();
			} catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}
	}
}
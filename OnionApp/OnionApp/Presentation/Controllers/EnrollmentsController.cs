using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.DTO;
using OnionApp.Application.Services;
using OnionApp.Core.Services;

namespace OnionApp.Presentation.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EnrollmentsController : ControllerBase
	{
		private readonly IEnrollmentService _enrollmentService;

		public EnrollmentsController(IEnrollmentService enrollmentService)
		{
			_enrollmentService = enrollmentService;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAllEnrollments()
		{
			var enrollments = await _enrollmentService.GetAllEnrollmentsAsync();
			return Ok(enrollments);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetUser(int id)
		{
			var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
			if (enrollment == null)
				return NotFound();

			return Ok(enrollment);
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateEnrollments([FromBody] EnrollmentDto request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				await _enrollmentService.CreateEnrollmentAsync(request);
				return Created();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("edit/{id}")]
		public async Task<IActionResult> UpdateEnrollment(int id, [FromBody] EnrollmentUpdateDto request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				await _enrollmentService.UpdateEnrollmentAsync(id, request);
				return Ok();
			}
			catch (KeyNotFoundException)
			{
				return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteEnrollment(int id)
		{
			try
			{
				await _enrollmentService.DeleteEnrollmentAsync(id);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}

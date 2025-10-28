using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnionApp.Application.DTO;
using OnionApp.Application.Services;
using OnionApp.Core.Services;
using System.Threading.Tasks;

namespace OnionApp.Presentation.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ModulesController : ControllerBase
	{
		private readonly IModuleService _moduleService;

		public ModulesController(IModuleService moduleService)
		{
			_moduleService = moduleService;
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAllModules()
		{
			var modules = await _moduleService.GetAllModulesAsync();
			return Ok(modules);
		}

		// GET: Modules/by-course/5
		[HttpGet("by-course/{courseId}")]
		public async Task<IActionResult> GetModulesByCourseId(int courseId)
		{
			var modules = await _moduleService.GetModulesByCourseIdAsync(courseId);

			return Ok(modules);
		}

		// POST: Modules/Create
		[HttpPost("create")]
		public async Task<IActionResult> CreateModule([FromBody] ModuleDto request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				await _moduleService.CreateModuleAsync(request);
				return Created();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// POST: Modules/Edit/5
		[HttpPost("edit/{id}")]
		public async Task<IActionResult> Edit(int id, [FromBody] ModuleUpdateDto request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				await _moduleService.UpdateModuleAsync(id, request);
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

		// GET: Modules/Delete/5
		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _moduleService.DeleteModuleAsync(id);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}

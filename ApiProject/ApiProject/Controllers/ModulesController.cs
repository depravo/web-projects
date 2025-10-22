using ApiProject.Model;
using Azure.Core;
using CreateDBProj;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace ApiProject.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ModulesController : ControllerBase {
		private readonly ApplicationContext _context;

		public ModulesController(ApplicationContext context) {
			_context = context;
		}

		// GET: Modules/by-course/3
		[HttpGet("by-course/{courseId}")]
		public IActionResult ModulesByCourse(int? courseId) {
			if (courseId == null) {
				return NotFound();
			}
			var res = new List<Module>();
			try {
				var course = _context.Courses.Include(c => c.Modules).Where(c => c.Id == courseId).FirstOrDefault();
				if (course != null) {
					res = course.Modules.ToList();
				} else {
					return NotFound();
				}
				foreach (var m in res) {
					_context.Entry(m).Reference(cr => cr.Course).CurrentValue = null;
				}
			} catch (Exception e) {
				NotFound(e.Message);
			}
			return Ok(res);
		}

		// GET: Modules/5
		[HttpGet("{id}")]
		public IActionResult Details(int? id) {
			if (id == null) {
				return NotFound();
			}

			var module = _context.Modules
				.FirstOrDefault(m => m.Id == id);
			if (module == null) {
				return NotFound();
			}

			return Ok(module);
		}

		// POST: Modules/Create
		[HttpPost("create")]
		public IActionResult Create([FromBody] ModuleDto request) {
			if (request != null) {
				var course = _context.Courses.First(c => c.Id == request.CourseId);
				if (course == null) {
					return BadRequest();
				}
				var module = new Module(request.Title, request.OrderNumber, request.CourseId);
				_context.Add(module);
				_context.SaveChanges();
				return Created();
			}
			return BadRequest();
		}

		// POST: Modules/Edit/5
		[HttpPost("edit/{id}")]
		public IActionResult Edit(int? id, [FromBody] ModuleDto request) {
			var module = _context.Modules.Find(id);
			if (module == null) {
				return NotFound($"Module with ID {id} not found");
			}
			if (!string.IsNullOrEmpty(request.Title))
				module.Title = request.Title;

			if (request.OrderNumber != null)
				module.OrderNumber = request.OrderNumber;

			if (request.CourseId != null)
				module.CourseId = request.CourseId;

			try {
				_context.Update(module);
				_context.SaveChanges();
				return Ok();
			} catch (DbUpdateConcurrencyException) {
				return Conflict("The module was modified by another process");
			} catch (Exception ex) {
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		// GET: Modules/Delete/5
		[HttpDelete("delete/{id}")]
		public IActionResult Delete(int? id) {
			if (id == null) {
				return NotFound();
			}

			var module = _context.Modules
				.Find(id);
			if (module != null) {
				_context.Modules.Remove(module);
				_context.SaveChanges();
				return Ok();
			}

			return BadRequest();
		}

	}
}

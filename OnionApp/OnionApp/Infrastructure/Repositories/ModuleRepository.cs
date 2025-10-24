using Microsoft.EntityFrameworkCore;
using OnionApp.Core.Entities;
using OnionApp.Core.Interfaces;
using OnionApp.Infrastructure.Data;

namespace OnionApp.Infrastructure.Repositories {
	public class ModuleRepository : IModuleRepository {

		private readonly ApplicationDbContext _context;

		public ModuleRepository(ApplicationDbContext context) {
			this._context = context;
		}
		public async Task AddAsync(Module entity) {
			_context.Modules.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id) {
			var module = _context.Modules.FirstOrDefault(m => m.Id == id);
			_context.Modules.Remove(module);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Module>> GetAllAsync() {
			return await _context.Modules.ToListAsync();
		}

		public async Task<Module> GetByIdAsync(int id) {
			return await _context.Modules.FirstOrDefaultAsync(m => m.Id == id);
		}

		public async Task<IEnumerable<Module>> GetModulesByCourse(int courseId) {
			var course = await _context.Courses.Include(c => c.Modules).FirstOrDefaultAsync(c => c.Id == courseId);
			return course.Modules.ToList();
		}

		public async Task UpdateAsync(Module entity) {
			_context.Modules.Update(entity);
			await _context.SaveChangesAsync();

		}
	}
}

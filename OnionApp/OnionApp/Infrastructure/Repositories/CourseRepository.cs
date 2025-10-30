using Microsoft.EntityFrameworkCore;
using OnionApp.Core.Entities;
using OnionApp.Core.Interfaces;
using OnionApp.Infrastructure.Data;

namespace OnionApp.Infrastructure.Repositories {
	public class CourseRepository : ICourseRepository {

		private readonly ApplicationDbContext _context;

		public CourseRepository(ApplicationDbContext context) {
			this._context = context;
		}

		public async Task AddAsync(Course entity) {
			_context.Courses.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id) {
			var course = _context.Courses.FirstOrDefault(c => c.Id == id);
			_context.Courses.Remove(course);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Course>> GetAllAsync() {
			return await _context.Courses.ToListAsync();
		}

		public async Task<Course> GetByIdAsync(int id) {
			return await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task UpdateAsync(Course entity) {
			_context.Courses.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}

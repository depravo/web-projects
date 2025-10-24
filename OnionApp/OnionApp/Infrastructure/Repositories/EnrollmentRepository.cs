using Microsoft.EntityFrameworkCore;
using OnionApp.Core.Entities;
using OnionApp.Core.Interfaces;
using OnionApp.Infrastructure.Data;

namespace OnionApp.Infrastructure.Repositories {
	public class EnrollmentRepository : IEnrollmentRepository {

		private readonly ApplicationDbContext _context;
		public EnrollmentRepository(ApplicationDbContext context) {
			this._context = context;
		}

		public async Task AddAsync(Enrollment entity) {
			_context.Enrollments.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id) {
			var enrollment = _context.Enrollments.FirstOrDefault(e => e.Id == id);
			_context.Enrollments.Remove(enrollment);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Enrollment>> GetAllAsync() {
			return await _context.Enrollments.ToListAsync();
		}

		public async Task<Enrollment> GetByIdAsync(int id) {
			return await _context.Enrollments.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task UpdateAsync(Enrollment entity) {
			_context.Enrollments.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}

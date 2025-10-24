using Microsoft.EntityFrameworkCore;
using OnionApp.Core.Entities;
using OnionApp.Core.Interfaces;
using OnionApp.Infrastructure.Data;

namespace OnionApp.Infrastructure.Repositories {
	public class CourseReviewRepository : ICourseReviewRepository {

		private readonly ApplicationDbContext _context;

		public CourseReviewRepository(ApplicationDbContext context) {
			this._context = context;
		}

		public async Task AddAsync(CourseReview entity) {
			_context.CourseReviews.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id) {
			var courseReview = _context.CourseReviews.FirstOrDefault(cr => cr.Id == id);
			_context.CourseReviews.Remove(courseReview);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<CourseReview>> GetAllAsync() {
			return await _context.CourseReviews.ToListAsync();
		}

		public async Task<CourseReview> GetByIdAsync(int id) {
			return await _context.CourseReviews.FirstOrDefaultAsync(cr => cr.Id == id);
		}

		public async Task UpdateAsync(CourseReview entity) {
			_context.CourseReviews.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}

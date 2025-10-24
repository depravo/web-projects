using Microsoft.EntityFrameworkCore;
using OnionApp.Core.Entities;
using OnionApp.Core.Interfaces;
using OnionApp.Infrastructure.Data;

namespace OnionApp.Infrastructure.Repositories {
	public class UserRepository : IUserRepository {
		private readonly ApplicationDbContext _context;

		public UserRepository(ApplicationDbContext context) {
			this._context = context;
		}

		public async Task AddAsync(User entity) {
			_context.Users.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id) {
			var user = _context.Users.FirstOrDefault(u => u.Id == id);
			_context.Users.Remove(user);
			await _context.SaveChangesAsync();

		}

		public async Task<IEnumerable<User>> GetAllAsync() {
			return await _context.Users.ToListAsync();
		}

		public async Task<User> GetByIdAsync(int id) {
			return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
		}

		public async Task UpdateAsync(User entity) {
			_context.Users.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}

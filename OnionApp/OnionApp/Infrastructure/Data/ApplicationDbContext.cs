using Microsoft.EntityFrameworkCore;
using OnionApp.Core.Entities;

namespace OnionApp.Infrastructure.Data {
	public class ApplicationDbContext : DbContext{
		public DbSet<User> Users { get; set; } = null!;
		public DbSet<Course> Courses { get; set; } = null!;
		public DbSet<Module> Modules { get; set; } = null!;
		public DbSet<Enrollment> Enrollments { get; set; } = null!;
		public DbSet<CourseReview> CourseReviews { get; set; } = null!;

		public ApplicationDbContext() {
			Database.EnsureCreated();
		}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) {
			Database.EnsureCreated();  
		}
	}
}

using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDBProj {
	public class ApplicationContext : DbContext {
		public DbSet<User> Users { get; set; } = null!;
		public DbSet<Course> Courses { get; set; } = null!;
		public DbSet<Module> Modules { get; set; } = null!;
		public DbSet<Enrollment> Enrollments { get; set; } = null!;
		public DbSet<CourseReview> CourseReviews { get; set; } = null!;

		public ApplicationContext() {
			Database.EnsureCreated();
		}

		public ApplicationContext(DbContextOptions<ApplicationContext> options)
		: base(options) {
			Database.EnsureCreated();   // создаем базу данных при первом обращении
		}
	}
}

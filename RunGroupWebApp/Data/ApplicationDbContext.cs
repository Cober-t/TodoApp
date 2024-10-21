using Microsoft.EntityFrameworkCore;
using TodoApp.Data.Enum;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Project> Projects  { get; set; }
        public DbSet<SubProject> SubProjects{ get; set; }
        public DbSet<ToDo> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 

        }

		// seed data
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Project>().HasData(
				new Project { Id = 1, Title = "Learn English", Value = 200 },
				new Project { Id = 2, Title = "Physically Base Render Book", Value = 300 }
			);

			modelBuilder.Entity<SubProject>().HasData(
				new SubProject { Id = 1, ProjectID = 1, Title = "Present Continuous" },
				new SubProject { Id = 2, ProjectID = 2, Title = "Chapter 1" },
				new SubProject { Id = 3, ProjectID = 2, Title = "Chapter 2" }
			);

			modelBuilder.Entity<ToDo>().HasData(
				new ToDo { Id = 1, SubProjectID = 2, Title = "Debug Test" },
				new ToDo { Id = 2, SubProjectID = 3, Title = "Monte-Carlo Implementation 1" },
				new ToDo { Id = 3, SubProjectID = 3, Title = "Monte-Carlo Implementation 2" },
				new ToDo { Id = 4, SubProjectID = 1, Title = "Task 1" },
				new ToDo { Id = 5, SubProjectID = 1, Title = "Task 2" },
                new ToDo { Id = 6, SubProjectID = 3, Title = "Monte-Carlo Implementation 3" }
            );
        }
    }
}
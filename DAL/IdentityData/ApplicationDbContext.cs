using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.IdentityData
{
	public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

		//public DbSet<Classroom> Classrooms { get; set; }
		public DbSet<Exam> Exams { get; set; }
		//public DbSet<Subject> Subjects { get; set; }
        //public DbSet<Question> Questions { get; set; }
        //public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);

			//builder.Entity<Classroom>()
			//    .HasOne(c => c.TeacherId)
			//    .WithMany(t=>t.clas)

			//builder.Entity<Grade>()
			//	.HasOne(g=>g.StudentId)
			//	.WithMany()

		}
    }
}

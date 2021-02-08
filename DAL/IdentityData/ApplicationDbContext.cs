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
		public DbSet<Subject> Subjects { get; set; }
		//public DbSet<Question> Questions { get; set; }
		//public DbSet<Grade> Grades { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);

			builder.Entity<Exam>()
				.HasOne(e => e.Teacher)
				.WithMany(t => t.Exams);

			builder.Entity<Exam>()
				.HasMany(e => e.Students)
				.WithMany(s => s.Exams)
				.UsingEntity<Grade>(
					j => j
						.HasOne(g => g.Student)
						.WithMany(s => s.Grades) // todo: maybe try to get rid of the grades properties where theyre not needed
						.HasForeignKey(g => g.StudentId),
					j => j
						.HasOne(g => g.Exam)
						.WithMany(e => e.Grades)
						.HasForeignKey(g => g.ExamId),
					j =>
					{
						j.ToTable("StudentsExamsGrades");
						j.HasKey(g => new { g.StudentId, g.ExamId });
					});

			builder.Entity<Exam>()
				.HasOne(e => e.Subject)
				.WithMany(s => s.Exams)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Exam>()
				.Property(typeof(int?), "SubjectId")
				.IsRequired(false);
		}
	}
}

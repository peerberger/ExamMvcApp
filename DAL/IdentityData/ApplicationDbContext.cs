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

			//builder.Entity<Student>()
			//.Property(s => s.Exams)
			//.HasColumnName("Exams");

			//builder.Entity<Teacher>()
			//	.Property(t => t.Exams)
			//	.HasColumnName("Exams");

			//builder.Entity<AppUser>()
			//   .HasDiscriminator()
			//   .HasValue<Student>("Student")
			//   .HasValue<Teacher>("Teacher");

			builder.Entity<Exam>()
				.HasOne(e => e.Teacher)
				.WithMany(t => t.Exams);

			builder.Entity<Exam>()
				.HasMany(e => e.Students)
				.WithMany(s => s.Exams)
				.UsingEntity(j =>
				{
					j.ToTable("ExamsUsers");

					j.Property(typeof(int), "ExamsId")
						.HasColumnName("ExamId");

					j.Property(typeof(string), "StudentsId")
						.HasColumnName("StudentId");
				});
		}
	}
}

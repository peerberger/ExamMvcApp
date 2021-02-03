using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using DAL.IdentityData;
using Microsoft.AspNetCore.Authorization;
using DAL.Repositories.UnitOfWorks;
using PL.Models.Shared;
using PL.Models.Student;
using PL.BLL;

namespace PL.Controllers
{
	public class StudentController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IUnitOfWork _unitOfWork;

		public StudentController(
			UserManager<AppUser> userManager,
			IUnitOfWork unitOfWork)
		{
			_userManager = userManager;
			_unitOfWork = unitOfWork;
		}

		// GET: StudentController
		[Authorize]
		public async Task<ActionResult> Index()
		{

			//ClearExams();
			//SeedExams();

			//var exam = _unitOfWork.Exams.GetByIdIncludingUsers(20);

			//var student = await _userManager.GetUserAsync(User);

			//exam.Users.Add(student);
			//_unitOfWork.SaveChanges();
			

			//var users = _unitOfWork.Exams.GetAllIncludingStudents();



			
			var exams = _unitOfWork.Exams.GetByStudentIncludingGradesAsNoTracking(User);

			var indexViewModel = StudentViewModelsGenerator.GenerateIndexViewModel(exams);

			return View(indexViewModel);
			//return View("IndexTemplate", exams);
		}

		private void SeedExams()
		{
			var exams = new List<Exam>
			{
				new Exam{Subject = "math",Title = "calculus",Duration = TimeSpan.FromMinutes(1)},
				new Exam{Subject = "math",Title = "algebra",Duration = TimeSpan.FromMinutes(2)},
				new Exam{Subject = "math",Title = "blabla",Duration = TimeSpan.FromMinutes(3)}
			};

			_unitOfWork.Exams.AddRange(exams);
			_unitOfWork.SaveChanges();
		}

		private void ClearExams()
		{
			var exams = _unitOfWork.Exams.GetAll();

			_unitOfWork.Exams.RemoveRange(exams);
			_unitOfWork.SaveChanges();
		}



		// GET: StudentController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: StudentController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: StudentController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: StudentController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: StudentController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: StudentController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: StudentController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}

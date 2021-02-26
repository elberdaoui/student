using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using studentOneMethod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentOneMethod.Controllers
{
    
    public class StudentController : Controller
    {
        [BindProperty]
        public Student Student { get; set; }
        private readonly StudentContext _std;
        private readonly IToastNotification _toastNotification;

        public StudentController(StudentContext std, IToastNotification toastNotification)
        {
            _std = std;
            _toastNotification = toastNotification;
        }

        #region List and Search
        public IActionResult Index()
        {

            var list = _std.students.ToList();
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            var studenSearch = from m in _std.students
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                studenSearch = studenSearch.Where(s => s.FName.Contains(searchString) || s.LName.Contains(searchString) || s.CIN.Contains(searchString));
            }

            return View(await studenSearch.ToListAsync());
        }
        #endregion
        //[Authorize]
        #region CreateOrUpdate
        [HttpGet]
        public IActionResult CreateOrUpdate(int? id)
        {
            Student = new Student();

            if(id == null)
            {
                // create a new one
                return View(Student);
            }
            // update the exist one
            Student = _std.students.FirstOrDefault(s => s.id == id);
            if(Student == null)
            {
                return NotFound();
            }
            return View(Student);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrUpdate()
        {
            if (ModelState.IsValid)
            {
                if(Student.id == 0)
                {
                    _std.Add(Student);
                    _toastNotification.AddSuccessToastMessage("Student added successfully");
                }
                else
                {
                    _std.Update(Student);
                    _toastNotification.AddSuccessToastMessage("Student updated successfully");
                }
                _std.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Student);
        }
        #endregion
        [Authorize]
        public IActionResult Delete(int? id)
        {
            var del = _std.students.FirstOrDefault(d => d.id == id);
            
            return View(del);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var del = _std.students.FirstOrDefault(d => d.id == id);
            _std.students.Remove(del);
            _std.SaveChanges();
            _toastNotification.AddWarningToastMessage("Student Deleted");
            return RedirectToAction("Index");
            
        }
    }
}

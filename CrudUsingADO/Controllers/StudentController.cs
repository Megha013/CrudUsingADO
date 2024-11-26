using CrudUsingADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingADO.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration configuration;
        StudentCrud db;
        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db = new StudentCrud(this.configuration);
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var response = db.GetStudents();
            return View(response);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int rollno)
        {
            var res = db.GetStudentById(rollno);
            return View(res);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student stu)
        {
            try
            {
                int response = db.AddStudent(stu);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int rollno)
        {
            var res = db.GetStudentById(rollno);
            return View(res);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student stu)
        {
            try
            {
                int response = db.UpdateStudent(stu);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int rollno)
        {
            var res = db.GetStudents();
            return View(res);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int rollno)
        {
            try
            {
                int response = db.DeleteStudent(rollno);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }
    }
}

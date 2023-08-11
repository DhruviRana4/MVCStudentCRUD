using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class StudentController : Controller
    {
        static List<StudentClass> students=new List<StudentClass>();

        public StudentController()
        {
            if(students.Count == 0)
            {
                students.Add(new StudentClass { Id = 1, Name = "Dhruvi", Age = 19 });
                students.Add(new StudentClass { Id = 2, Name = "ABC", Age = 19 });
            }
        }

        private StudentClass GetStudent(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }
        // GET: Student
        public ActionResult Index()
        {
            return View(students.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View(GetStudent(id));
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentClass obj)
        {
            try
            {
                // TODO: Add insert logic here
                obj.Id=students.Max(x => x.Id)+1;
                students.Add(obj);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetStudent(id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentClass obj)
        {
            try
            {
                // TODO: Add update logic here
                StudentClass stud=GetStudent(id);
                stud.Name = obj.Name;
                stud.Age = obj.Age;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View(GetStudent(id));
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                students.Remove(GetStudent(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

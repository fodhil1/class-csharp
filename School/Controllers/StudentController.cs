using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School.Models;

namespace School.Controllers
{
    public class StudentController : Controller
    {
        public static List<Student> Students = new List<Student> { };
                    

        public ActionResult Index()
        {
            using (var schoolContext = new SchoolContext())
            {
                var studentList = new StudentListViewModel
                {
                    // Convert each Student to a StudentViewModel
                    Students = schoolContext.Students.Select(p => new StudentViewModel
                    {
                        StudentId = p.StudentId,
                        LastName = p.LastName,
                        FirstName = p.FirstName
                    }).ToList()
                };

                studentList.TotalStudents = studentList.Students.Count;

                return View(studentList);
            }
        }
        // Detail
        public ActionResult StudentDetail(int id)
        {
            using (var schoolContext = new SchoolContext())
            {
                var student = schoolContext.Students.SingleOrDefault(p => p.StudentId == id);
                if (student != null)
                {
                    var studentViewModel = new StudentViewModel
                    {
                        StudentId = student.StudentId,
                        LastName = student.LastName,
                        FirstName = student.FirstName
                    };

                    return View(studentViewModel);
                }

                return new HttpNotFoundResult();
            }
        }

        // Add action to add a student to our data.
        public ActionResult StudentAdd()
        {
            var studentViewModel = new StudentViewModel();

            return View("AddEditStudent", studentViewModel);
        }
        [HttpPost]
        public ActionResult AddStudent(StudentViewModel studentViewModel)
        {
            using (var schoolContext = new SchoolContext())
            {
                var nextStudentId = schoolContext.Students.Max(p => p.StudentId) + 1;

                var student = new Student
                {
                    StudentId = nextStudentId,
                    LastName = studentViewModel.LastName,
                    FirstName = studentViewModel.FirstName
                };

                schoolContext.Students.Add(student);

                return RedirectToAction("Index");
            }
        }
        // Here we can edit any student.
        public ActionResult StudentEdit(int id)
        {
            using (var schoolContext = new SchoolContext())
            {
                var student = schoolContext.Students.SingleOrDefault(p => p.StudentId == id);
                if (student != null)
                {
                    var studentViewModel = new StudentViewModel
                    {
                        StudentId = student.StudentId,
                        LastName = student.LastName,
                        FirstName = student.FirstName
                    };

                    return View("AddEditStudent", studentViewModel);
                }

                return new HttpNotFoundResult();
            }
        }
        [HttpPost]
        public ActionResult EditStudent(StudentViewModel studentViewModel)
        {
            using (var schoolContext = new SchoolContext())
            {
                var student = schoolContext.Students.SingleOrDefault(p => p.StudentId == studentViewModel.StudentId);

                if (student != null)
                {
                    student.LastName = studentViewModel.LastName;
                    student.FirstName = studentViewModel.FirstName;

                    return RedirectToAction("Index");
                }

                return new HttpNotFoundResult();
            }
        }

        // Delete action is used to remove any student from our data.
        [HttpPost]
        public ActionResult DeleteStudent(StudentViewModel studentViewModel)
        {
            using (var schoolContext = new SchoolContext())
            {
                var student = schoolContext.Students.SingleOrDefault(p => p.StudentId == studentViewModel.StudentId);

                if (student != null)
                {
                    schoolContext.Students.Remove(student);

                    return RedirectToAction("Index");
                }

                return new HttpNotFoundResult();
            }
        }







    }
}

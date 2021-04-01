using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            //if (Session["username"] == null)
              //  return RedirectToAction("Login", "User");
            if (Session["students"] == null)
            {
                List<Student> listStudent = new List<Student>();
                for (int i = 0; i < 10; i++)
                    listStudent.Add(new Student("Học sinh " + (i + 1),20));
                Session["students"] = listStudent;
            }
            return View(((List<Student>)Session["students"]));
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, int age, string name)
        {
            List<Student> listStudent = ((List<Student>)Session["students"]);
            int findIndex = listStudent.FindLastIndex(x => x.id == id);
            
            if (findIndex != -1)
            {
                listStudent[findIndex].age = age;
                listStudent[findIndex].name = name;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            List<Student> listStudent = ((List<Student>)Session["students"]);
            int findIndex = listStudent.FindLastIndex(x => x.id == id);
            Student st = new Student("", 0);
            if (findIndex != -1)
            {
                st.age = listStudent[findIndex].age;
                st.name = listStudent[findIndex].name;
            }
            
            return View(st);
        }

        public ActionResult Delete(int id)
        {
            List<Student> listStudent = ((List<Student>)Session["students"]);
            listStudent.RemoveAll(x => x.id == id);
            return RedirectToAction("Index", "Student");
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string name, int age) 
        {
            ((List<Student>)Session["students"]).Add(new Student(name, age));
            return RedirectToAction("Index", "Student");
        }

        [HttpPost]
        public ActionResult Delete()
        {
            return RedirectToAction("Index", "Student");
        }
    }
}
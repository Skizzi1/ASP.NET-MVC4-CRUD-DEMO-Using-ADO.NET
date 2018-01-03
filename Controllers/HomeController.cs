using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Demo.Models;
using MVC_Demo.Repository;

namespace MVC_Demo.Controllers
{
    public class HomeController : Controller
    {

        Employees emp = new Employees();

        // GET: Home
        public ActionResult Demo()
        { 
            List<Employee> employeeList = emp.Read().ToList(); 
            return View(employeeList);
        }


        // GET: /Home/Create
        public ActionResult Create()
        {

            return View();
        }


        // POST: /Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee e)
        {
            e.guid = Guid.NewGuid();
            emp.Create(e);

            return RedirectToAction("Demo", "Home", new { area = "" });
        }


        // GET: /Home/Detail/id
        public ActionResult Detail(Guid? id)
        {
            Employee e = emp.Read().Single(x => x.guid == id); 
            return View(e);
        }


        // GET: /Home/Edit/id
        public ActionResult Edit(Guid? id)
        {
            Employee e = emp.Read().Single(x => x.guid == id);
            return View(e);
        }

        // POST: /Home/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee e)
        { 
            emp.Edit(e); 
            return RedirectToAction("Demo", "Home", new { area = "" });
        }

        // GET: /Home/Delete/id
        public ActionResult Delete(Guid? id)
        {
            Employee e = emp.Read().Single(x => x.guid == id);
            return View(e);
        }

        // POST: /Home/Delete/id
        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult Delete(Guid id)
        {
            
            emp.Delete(id);
            return RedirectToAction("Demo", "Home");
        }


    }
}
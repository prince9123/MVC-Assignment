using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvc2.Models;
using WebMvc2.service;

namespace WebMvc2.Controllers
{
    public class EmployeeController : Controller
    {
        private Employeeservice _empService;

        public ActionResult List()
        {
            _empService = new Employeeservice();
            var model = _empService.GetEmployeeList();
            return View(model);

        }
        public ActionResult AddEmployee()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddEmployee(EmployeeModel model)
        {
            _empService = new Employeeservice();

            _empService.insertEmployee(model);

            return RedirectToAction("List");




        }
            
        public ActionResult EditEmployee(int Emp_ID)
        {
            _empService = new Employeeservice();
            var model = _empService.GetEditById(Emp_ID);

            return View(model);
        }
        [HttpPost]
        public ActionResult EditEmployee(EmployeeModel model)
        {
            _empService = new Employeeservice();
            _empService.UpdateEmp(model);
            return RedirectToAction("List");

        }
        public ActionResult DeleteEmployee(int Emp_ID)
        {
            _empService = new Employeeservice();

            _empService.DeleteEmp(Emp_ID);
            return RedirectToAction("List");
        }
    }
}
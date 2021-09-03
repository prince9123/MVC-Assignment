using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvc2.Models;
using WebMvc2.service;

namespace WebMvc2.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectController _empservices;
        GET: Project
        public ActionResult List()
        {
            _empservices = new Projectservices();
            var model = _empservices.GetEditByProid();
            return View(model);
        }
        public ActionResult AddProject()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddProject(ProjectModel model)
        {
            _empservices = new ProjectService();
            _empservices.insertProject(model);

            return RedirectToAction("List");
        }

        private void insertProject(ProjectModel model)
        {
            throw new NotImplementedException();
        }

        public ActionResult EditProject(int Proid)
        {
            var model = _empservices.GetEditByProid(Proid);
            return View(model);
        }

        private object GetEditByProid(int proid)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult EditProject(ProjectModel model)
        {
            _empservices.UpdatePro(model);
            return RedirectToAction("List");
        }

        private void UpdatePro(ProjectModel model)
        {
            throw new NotImplementedException();
        }

        public ActionResult DeleteProject(int Proid)
        {
            _empservices.DeleteProject(Proid);
            return RedirectToAction("List");

        }

        public static implicit operator ProjectController(ProjectService v)
        {
            throw new NotImplementedException();
        }
    }
}





    

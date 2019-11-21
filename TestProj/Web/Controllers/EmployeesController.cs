using DataTransferObject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;
using Web.Service;

namespace Web.Controllers
{
    public class EmployeesController : Controller
    {
        EmpService _service = new EmpService();

        // GET: Employees
        public ActionResult Index()
        {
            var data = this._service.Read();
            if (data.State == StateEnum.Success)
            {
                return View(data.Data);
            }

            ViewBag.Error = data.Message;
            return View("Error");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateConfirm(Employee4AccessVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            var result = this._service.Create(model);
            if (result.State == StateEnum.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = result.Message;
                return View("Error");
            }
        }

        public ActionResult Update(int id)
        {
            var data = this._service.Find(id);
            if (data.State == StateEnum.Success)
            {
                var emp = JsonConvert.DeserializeObject<Employee4AccessVM>(data.Message);
                return View(emp);
            }
            else
            {
                ViewBag.Error = data.Message;
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateConfirm(Employee4AccessVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("Update");
            }

            var result = this._service.Update(model);
            if (result.State == StateEnum.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = result.Message;
                return View("Error");
            }
        }

        public ActionResult Delete(int id)
        {
            var result = this._service.Delete(id);
            if (result.State == StateEnum.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = result.Message;
                return View("Error");
            }
        }

        public ActionResult Details(int id)
        {
            var data = this._service.Find(id);
            if (data.State == StateEnum.Success)
            {
                var emp = JsonConvert.DeserializeObject<Employee4AccessVM>(data.Message);
                return View(emp);
            }
            else
            {
                ViewBag.Error = data.Message;
                return View("Error");
            }
        }
    }
}
using DataTransferObject;
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
            var data = this._service.GetEmployeeList();
            if (data.State == StateEnum.Success)
            {
                return View(data.Data);
            }

            ViewBag.Error = data.Message;
            return View("Error");
        }
    }
}
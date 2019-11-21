using API.EF;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class EmployeesController : ApiController
    {
        EmployeeDao _dao = new EmployeeDao();

        [HttpGet]
        public EmployeeCollection GetEmployeeList()
        {
            return this._dao.Read();
        }

        [HttpPost]
        public CommonRequest Create(Employees model)
        {
            this._dao.Create(model);
            return new CommonRequest()
            {
                State = StateEnum.Success,
            };
        }
    }
}

using API.EF;
using DataTransferObject;
using Newtonsoft.Json;
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
        public EmployeeCollection Read()
        {
            return this._dao.Read();
        }

        [HttpGet]
        public CommonRequest Find(int id)
        {
            var result = new CommonRequest();

            var data = this._dao.Find(id);
            if (data == null)
            {
                result.State = StateEnum.Fail;
                result.Message = "查無資料";
            }
            else
            {
                result.State = StateEnum.Success;
                result.Message = JsonConvert.SerializeObject(data);
            }

            return result;
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

        [HttpPost]
        public CommonRequest Update(Employees model)
        {
            var result = new CommonRequest();

            if (this._dao.Update(model))
            {
                result.State = StateEnum.Success;
            }
            else
            {
                result.State = StateEnum.Fail;
                result.Message = "無更新項目";
            }

            return result;
        }

        [HttpPost]
        public CommonRequest Delete(int id)
        {
            var result = new CommonRequest();

            if (this._dao.Delete(id))
            {
                result.State = StateEnum.Success;
            }
            else
            {
                result.State = StateEnum.Fail;
                result.Message = "無刪除項目";
            }

            return result;
        }
    }
}

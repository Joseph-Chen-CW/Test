using DataTransferObject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using Utility;

namespace Web.Service
{
    internal class EmpService
    {
        string _apiUrl = ConfigurationManager.AppSettings["ApiUrl"];

        internal EmployeeCollection Read()
        {
            var url = $"{this._apiUrl}/Employees/Read";
            var json = HttpConnector.Get(url);
            if (json.State == StateEnum.Success)
            {
                return JsonConvert.DeserializeObject<EmployeeCollection>(json.Message);
            }

            var error = new EmployeeCollection()
            {
                State = StateEnum.Fail,
                Message = json.Message,
            };
            return error;
        }

        internal CommonRequest Find(int id)
        {
            var url = $"{this._apiUrl}/Employees/Find?id={id}";
            var json = HttpConnector.Get(url);
            if (json.State == StateEnum.Success)
            {
                return JsonConvert.DeserializeObject<CommonRequest>(json.Message);
            }
            else
            {
                return json;
            }
        }

        internal CommonRequest Create(Employee4AccessVM model)
        {
            var url = $"{this._apiUrl}/Employees/Create";
            var json = HttpConnector.Post(url, JsonConvert.SerializeObject(model), Encoding.UTF8);
            if (json.State == StateEnum.Timeout)
            {
                return json;
            }
            return JsonConvert.DeserializeObject<CommonRequest>(json.Message);
        }

        internal CommonRequest Update(Employee4AccessVM model)
        {
            var url = $"{this._apiUrl}/Employees/Update";
            var json = HttpConnector.Post(url, JsonConvert.SerializeObject(model), Encoding.UTF8);
            if (json.State == StateEnum.Timeout)
            {
                return json;
            }
            return JsonConvert.DeserializeObject<CommonRequest>(json.Message);
        }
    }
}
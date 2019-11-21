using DataTransferObject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Utility;

namespace Web.Service
{
    internal class EmpService
    {
        string _apiUrl = ConfigurationManager.AppSettings["ApiUrl"];

        internal EmployeeCollection GetEmployeeList()
        {
            var url = $"{this._apiUrl}/Employees/GetEmployeeList";
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
    }
}
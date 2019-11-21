using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.EF
{
    internal class EmployeeDao
    {
        NorthwindEntities _db = new NorthwindEntities();

        public EmployeeCollection Read()
        {
            var result = new EmployeeCollection()
            {
                State = StateEnum.Success,
                Data = new List<EmployeeData>(),
            };

            foreach (var item in this._db.Employees)
            {
                var data = new EmployeeData()
                {
                    ID = item.EmployeeID,
                    Name = $"{item.LastName} {item.FirstName}",
                    BirthDate = item.BirthDate,
                    Phone = item.HomePhone,
                    Title = item.Title,
                    Address = $"{item.Country} {item.City} {item.Region} {item.Address}",
                };
                result.Data.Add(data);
            }

            return result;
        }

        public void Create(Employees model)
        {
            this._db.Employees.Add(model);
            this._db.SaveChanges();
        }
    }
}
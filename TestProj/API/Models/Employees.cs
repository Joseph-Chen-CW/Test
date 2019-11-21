using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.EF
{
    [MetadataType(typeof(Employeespartial))]
    public partial class Employees
    {
    }
    public class Employeespartial
    {
        [JsonIgnore]
        public virtual ICollection<Employees> Employees1 { get; set; }
    }
}
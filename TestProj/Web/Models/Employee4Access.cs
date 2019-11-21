using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataTransferObject
{
    [MetadataType(typeof(Employee4AccessVM))]
    public partial class Employee4Access
    {
    }

    public class Employee4AccessVM : IValidatableObject
    {
        [Display(Name = "員工編號")]
        public int EmployeeID { get; set; }
        [Display(Name = "姓")]
        [Required(ErrorMessage = "請輸入姓")]
        public string LastName { get; set; }
        [Display(Name = "名")]
        [Required(ErrorMessage = "請輸入名")]
        public string FirstName { get; set; }
        [Display(Name = "職稱")]
        public string Title { get; set; }
        [Display(Name = "生日")]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "到職日")]
        public DateTime? HireDate { get; set; }
        [Display(Name = "地址")]
        public string Address { get; set; }
        [Display(Name = "城市")]
        public string City { get; set; }
        [Display(Name = "區域")]
        public string Region { get; set; }
        [Display(Name = "郵遞區號")]
        public string PostalCode { get; set; }
        [Display(Name = "國家")]
        public string Country { get; set; }
        [Display(Name = "電話")]
        public string HomePhone { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            var now = DateTime.Now;

            if (this.BirthDate.HasValue)
            {
                if ((now.Year - this.BirthDate.Value.Year) < 18)
                {
                    yield return new ValidationResult("請確認生日", new string[] { "BirthDate" });
                }
            }

            if (this.HireDate.HasValue)
            {
                if (now < this.HireDate.Value)
                {
                    yield return new ValidationResult("到職日不得大於今日", new string[] { "HireDate" });
                }
            }
        }
    }
}
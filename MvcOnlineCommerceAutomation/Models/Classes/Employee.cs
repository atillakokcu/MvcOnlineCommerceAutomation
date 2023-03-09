using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommerceAutomation.Models.Classes
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Display(Name ="Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeName { get; set; }

        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string EmployeeSurname { get; set; }

        [Display(Name = "Görsel")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string EmployeeImage { get; set; }


        public ICollection<SalesAction> SalesActions { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Departments { get; set; }

    }
}
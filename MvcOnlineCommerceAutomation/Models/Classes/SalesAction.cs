using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineCommerceAutomation.Models.Classes
{
    public class SalesAction
    {
        [Key]
        public int SalesId { get; set; }
        //ürün- product
        //müşteri- customer
        //personel- employee
        public DateTime Date { get; set; }
        public int Piece { get; set; }// adet demek
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }

        public Product Products { get; set; }
        public Customer Customers { get; set; }
        public Employee Employees { get; set; }

    }
}
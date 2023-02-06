using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineCommerceAutomation.Models.Classes
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set;}
        public string CustomerSurname { get; set;}
        public string CustomerCity { get; set;}
        public string CustomerMail { get; set;}
    }
}
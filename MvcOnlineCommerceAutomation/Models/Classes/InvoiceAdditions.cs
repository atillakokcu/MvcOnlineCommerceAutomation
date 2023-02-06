using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineCommerceAutomation.Models.Classes
{
    public class InvoiceAdditions
    {
        [Key]
        public int InvoiceAdditionsId { get; set; }
        public string InvoiceDescription { get; set; }
        public int InvoiceAmount { get; set; }
        public decimal InvoiceUnitPrice { get; set; }
        public decimal InvoiceTotalPrice { get; set; }

    }
}
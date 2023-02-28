using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommerceAutomation.Models.Classes
{
    public class InvoiceAdditions
    {
        [Key]
        public int InvoiceAdditionsId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string InvoiceDescription { get; set; }
        public int InvoiceAmount { get; set; }
        public decimal InvoiceUnitPrice { get; set; }
        public decimal InvoiceTotalPrice { get; set; }
        public int BillId { get; set; }
        public virtual Bills Bills { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineCommerceAutomation.Models.Classes
{
    public class Bills
    {
        [Key]
        public int BillId { get; set; }
        public char BillSerialNo { get; set; }
        public string BillSiraNo { get; set; }
        public DateTime BillDate { get; set; }
        public string TaxOffice { get; set; }
        public DateTime BillTime { get; set; }
        public string TeslimEden { get; set; }
        public string TeslimAlan { get; set; }
    }
}
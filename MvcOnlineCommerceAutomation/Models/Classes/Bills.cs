using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommerceAutomation.Models.Classes
{
    public class Bills
    {
        [Key]
        public int BillId { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public char BillSerialNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string BillSiraNo { get; set; }
        public DateTime BillDate { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxOffice { get; set; }
        public DateTime BillTime { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string TeslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string TeslimAlan { get; set; }
        public ICollection<InvoiceAdditions> InvoiceAdditionss { get; set; }
    }
}
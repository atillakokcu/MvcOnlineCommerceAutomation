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

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string BillSerialNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string BillSiraNo { get; set; }
        public DateTime BillDate { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxOffice { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string BillTime { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string TeslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string TeslimAlan { get; set; }

        public decimal Toplam { get; set; }

        public ICollection<InvoiceAdditions> InvoiceAdditionss { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommerceAutomation.Models.Classes
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipId { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string TakipKodu { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(200)]
        public string Aciklama { get; set; }
        public DateTime TarihZaman { get; set; }
    }
}
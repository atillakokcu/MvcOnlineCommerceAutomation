using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommerceAutomation.Models.Classes
{
    public class Detay
    {
        [Key]
        public int DetayId { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(50)]
        public string UrunAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(7000)]
        public string UrunBilgi { get; set; }
        

    }
}
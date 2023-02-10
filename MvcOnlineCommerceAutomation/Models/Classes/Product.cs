using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommerceAutomation.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ProductBrand { get; set; }
        public string ProductStock { get; set; }
        public decimal ProductPurchasePrice { get; set; }
        public decimal ProductSalePrice { get; set; }
        public bool Status { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string ProductImage { get; set; }
        public Category Category { get; set; }


        public ICollection<SalesAction> SalesActions { get; set; }
    }
}
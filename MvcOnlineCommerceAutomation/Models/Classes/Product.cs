using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineCommerceAutomation.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public string ProductStock { get; set; }
        public decimal ProductPurchasePrice { get; set; }
        public decimal ProductSalePrice { get; set; }
        public bool Status { get; set; }
        public string ProductImage { get; set; }
    }
}
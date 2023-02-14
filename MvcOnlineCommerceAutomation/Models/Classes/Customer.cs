using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommerceAutomation.Models.Classes
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="en fazla 30 karakter yazabilirsiniz")]
        public string CustomerName { get; set;}

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz..")]
        public string CustomerSurname { get; set;}

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CustomerCity { get; set;}

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CustomerMail { get; set;}

        public bool status { get; set; }

        public ICollection<SalesAction> SalesActions { get; set; }
    }
}
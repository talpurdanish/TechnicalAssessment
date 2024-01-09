using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment.Domain.ViewModels
{
    internal class OrderDetailViewModel
    {

        [Required(ErrorMessage = "Order Number is Required")]
        [DisplayName("Order Number")]
        public int OrderNum { get; set; }
        [Required(ErrorMessage = "Quantity is Required")]
        [DisplayName("Quantity")]
        public int Qty { get; set; }
        [Required(ErrorMessage = "Item is Required")]
        [DisplayName("Item")]
        [StringLength(250, ErrorMessage = "Item should be less than 250 chars")]
        public string Item { get; set; }
        [Required(ErrorMessage = "Price is Required")]
        [DisplayName("Price")]
        public double Price { get; set; }
        
    }
}

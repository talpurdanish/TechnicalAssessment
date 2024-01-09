using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment.Domain.ViewModels
{
    internal class OrderHeadViewModel
    {
        public int OrderNum { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [DisplayName("Name")]
        [StringLength(250, ErrorMessage = "Name should be less than 250 chars")]
        public string CustomerName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Date is Required")]
        [DisplayName("Date")]
        public string CreatedDate { get; set; }= string.Empty;
    }
}

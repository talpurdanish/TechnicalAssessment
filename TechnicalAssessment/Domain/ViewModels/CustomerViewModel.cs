using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment.Domain.ViewModels
{
    internal class CustomerViewModel
    {

        [Required(ErrorMessage = "Customer Name is Required")]
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public bool IsActive { get; set; }

        
    }
}

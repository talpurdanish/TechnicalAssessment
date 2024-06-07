using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment.Domain.Models
{
    internal class OrderHead
    {
        [Key]
        public int OrderNum { get; set; }
        
        public int CustomerId { get; set; }
        [Required]
        
        public DateTime CreatedDate { get; set; }

        public virtual Customer Customer{get; set; }
        public IEnumerable<OrderDtl> OrderDetails { get; set; }

    }
}

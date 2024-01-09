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
        [Required]
        [MaxLength(250)]
        public string CustomerName { get; set; } = string.Empty;
        [Required]
        
        public DateTime CreatedDate { get; set; }

        public IEnumerable<OrderDtl> OrderDetails { get; set; }

    }
}

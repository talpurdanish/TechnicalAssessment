using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment.Domain.Models
{
    internal class OrderDtl
    {
        [Key]
        public int OrderDtlID { get; set; }
        [Required]
        public int OrderNum { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        [MaxLength(300)]
        public string Item { get; set; }
        [Required]
        public double Price { get; set; }

        public OrderHead OrderHead {get; set; }

    }
}

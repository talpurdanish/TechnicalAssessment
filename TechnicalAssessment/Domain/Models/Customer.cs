using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment.Domain.Models
{
    internal class Customer
    {

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}

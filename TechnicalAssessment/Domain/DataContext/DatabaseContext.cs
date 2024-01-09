using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Domain.Models;

namespace TechnicalAssessment.Domain.DataContext
{
    internal class DatabaseContext:DbContext
    {


        public DatabaseContext():base()
        { }

        public DbSet<OrderHead> OrderHeads { get; set; }
        public DbSet<OrderDtl> OrderDetails { get; set; }
    }
}

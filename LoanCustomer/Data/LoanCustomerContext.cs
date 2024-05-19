using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanCustomer.Model;

namespace LoanCustomer.Data
{
    public class LoanCustomerContext : DbContext
    {
        public LoanCustomerContext (DbContextOptions<LoanCustomerContext> options)
            : base(options)
        {
        }

        public DbSet<LoanCustomer.Model.Cities> Cities { get; set; } = default!;
        public DbSet<LoanCustomer.Model.Customers> Customers { get; set; } = default!;
        public DbSet<LoanCustomer.Model.Loans> Loans { get; set; } = default!;
        public DbSet<LoanCustomer.Model.LoanTypes> LoanTypes { get; set; } = default!;
    }
}

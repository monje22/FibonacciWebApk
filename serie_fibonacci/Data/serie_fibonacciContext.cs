using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using serie_fibonacci.Models;

namespace serie_fibonacci.Data
{
    public class serie_fibonacciContext : DbContext
    {
        public serie_fibonacciContext (DbContextOptions<serie_fibonacciContext> options)
            : base(options)
        {
        }

        public DbSet<serie_fibonacci.Models.Fibonacci> Fibonacci { get; set; } = default!;
    }
}

using GerenciaEstoqueCQRSSemMediatR.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaEstoqueCQRSSemMediatR.Repository
{
    public class QueryDbContext : DbContext
    {
        public QueryDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}

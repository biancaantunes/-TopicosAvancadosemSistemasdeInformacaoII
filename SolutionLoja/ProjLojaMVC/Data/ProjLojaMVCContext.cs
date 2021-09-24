using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjLojaMVC.Models;

namespace ProjLojaMVC.Data
{
    public class ProjLojaMVCContext : DbContext
    {
        public ProjLojaMVCContext (DbContextOptions<ProjLojaMVCContext> options)
            : base(options)
        {
        }

        public DbSet<ProjLojaMVC.Models.Cliente> Cliente { get; set; }

        public DbSet<ProjLojaMVC.Models.Compra> Compra { get; set; }

        public DbSet<ProjLojaMVC.Models.Funcionario> Funcionario { get; set; }

        public DbSet<ProjLojaMVC.Models.Produto> Produto { get; set; }
    }
}

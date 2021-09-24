using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjLojaAPI.Model;

namespace ProjLojaAPI.Data
{
    public class ProjLojaAPIContext : DbContext
    {
        public ProjLojaAPIContext (DbContextOptions<ProjLojaAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ProjLojaAPI.Model.Cliente> Cliente { get; set; }

        public DbSet<ProjLojaAPI.Model.Compra> Compra { get; set; }

        public DbSet<ProjLojaAPI.Model.Funcionario> Funcionario { get; set; }

        public DbSet<ProjLojaAPI.Model.Produto> Produto { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjAula23._08.Models;

namespace ProjAula23._08.Data
{
    public class ProjAula23_08Context : DbContext
    {
        public ProjAula23_08Context (DbContextOptions<ProjAula23_08Context> options)
            : base(options)
        {
        }

        public DbSet<ProjAula23._08.Models.Fornecedor> Fornecedor { get; set; }

        public DbSet<ProjAula23._08.Models.Funcionario> Funcionario { get; set; }

        public DbSet<ProjAula23._08.Models.Produto> Produto { get; set; }
    }
}

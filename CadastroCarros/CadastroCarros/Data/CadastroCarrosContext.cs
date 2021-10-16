using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroCarros.Models;

namespace CadastroCarros.Data
{
    public class CadastroCarrosContext : DbContext
    {
        public CadastroCarrosContext (DbContextOptions<CadastroCarrosContext> options)
            : base(options)
        {
        }

        public DbSet<CadastroCarros.Models.Car> Car { get; set; }
    }
}

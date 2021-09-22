using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjMVCLocadoraCarro.Models;

namespace ProjLocadoraAPI.Data
{
    public class ProjLocadoraAPIContext : DbContext
    {
        public ProjLocadoraAPIContext (DbContextOptions<ProjLocadoraAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ProjMVCLocadoraCarro.Models.Carro> Carro { get; set; }

        public DbSet<ProjMVCLocadoraCarro.Models.Locacao> Locacao { get; set; }
    }
}

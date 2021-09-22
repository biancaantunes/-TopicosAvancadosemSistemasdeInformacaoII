using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjMVCLocadoraCarro.Models;

namespace ProjMVCLocadoraCarro.Data
{
    public class ProjMVCLocadoraCarroContext : DbContext
    {
        public ProjMVCLocadoraCarroContext (DbContextOptions<ProjMVCLocadoraCarroContext> options)
            : base(options)
        {
        }

        public DbSet<ProjMVCLocadoraCarro.Models.Carro> Carro { get; set; }

        public DbSet<ProjMVCLocadoraCarro.Models.Locacao> Locacao { get; set; }
    }
}

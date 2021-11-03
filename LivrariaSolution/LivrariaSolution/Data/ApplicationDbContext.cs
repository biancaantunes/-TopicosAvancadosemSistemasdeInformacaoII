using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using LivrariaSolution.Models;

namespace LivrariaSolution.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LivrariaSolution.Models.Autor> Autor { get; set; }
        public DbSet<LivrariaSolution.Models.Cliente> Cliente { get; set; }
        public DbSet<LivrariaSolution.Models.Compra> Compra { get; set; }
        public DbSet<LivrariaSolution.Models.Funcionario> Funcionario { get; set; }
        public DbSet<LivrariaSolution.Models.Livro> Livro { get; set; }
    }
}

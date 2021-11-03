using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BibliotecaComAutenticacao.Models;

namespace BibliotecaComAutenticacao.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BibliotecaComAutenticacao.Models.Autor> Autor { get; set; }
        public DbSet<BibliotecaComAutenticacao.Models.Cliente> Cliente { get; set; }
        public DbSet<BibliotecaComAutenticacao.Models.Emprestimo> Emprestimo { get; set; }
        public DbSet<BibliotecaComAutenticacao.Models.Livro> Livro { get; set; }
        public DbSet<BibliotecaComAutenticacao.Models.Status> Status { get; set; }
    }
}

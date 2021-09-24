using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjCursoMVC.Models;

namespace ProjCursoMVC.Data
{
    public class ProjCursoMVCContext : DbContext
    {
        public ProjCursoMVCContext (DbContextOptions<ProjCursoMVCContext> options)
            : base(options)
        {
        }

        public DbSet<ProjCursoMVC.Models.Aluno> Aluno { get; set; }

        public DbSet<ProjCursoMVC.Models.Curso> Curso { get; set; }

        public DbSet<ProjCursoMVC.Models.Disciplina> Disciplina { get; set; }
    }
}

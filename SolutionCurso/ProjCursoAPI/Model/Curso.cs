using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjCursoMVC.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaSolution.Models
{
    public class Compra
    {
        public int Id { get; set; }

        public virtual Cliente Cliente { get; set; }

        [NotMapped]
        [DisplayName("Cliente")]
        public virtual List<SelectListItem> Clientes { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        [NotMapped]
        [DisplayName("Funcionario")]
        public virtual List<SelectListItem> Funcionarios { get; set; }

        public virtual Livro Livro { get; set; }

        [NotMapped]
        [DisplayName("Livro")]
        public virtual List<SelectListItem> Livros { get; set; }


    }
}

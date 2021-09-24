using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjLojaMVC.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public virtual Cliente Cliente { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> Clientes { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> Funcionarios { get; set; }

        public virtual Produto Produto { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> Produtos { get; set; }

        public DateTime DataCompra { get; set; }
    }
}

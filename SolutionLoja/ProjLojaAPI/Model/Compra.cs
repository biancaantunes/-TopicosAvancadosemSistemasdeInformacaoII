using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjLojaAPI.Model
{
    public class Compra
    {
        public int Id { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public virtual Produto Produto { get; set; }
        public DateTime DataCompra { get; set; }
    }
}

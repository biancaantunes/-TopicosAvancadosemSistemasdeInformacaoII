using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMVCLocadoraCarro.Models
{
    public class Locacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual Carro Carro { get; set; }

    }
}

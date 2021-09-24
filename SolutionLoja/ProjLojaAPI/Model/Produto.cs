using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjLojaAPI.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
    }
}

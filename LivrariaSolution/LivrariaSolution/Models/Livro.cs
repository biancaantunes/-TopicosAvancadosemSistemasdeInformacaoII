﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaSolution.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public virtual Autor Autor { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> Autores { get; set; }

        [DisplayName("Data de Lançamento")]
        public DateTime Dtlancamento { get; set; }

        [DisplayName("Nome da Imagem")]
        public string Imagem { get; set; }

        [NotMapped]
        [DisplayName("Imagem do Livro")]
        public IFormFile ImagemLivro { get; set; }

        public virtual Status Status { get; set; }

        [NotMapped]
        [DisplayName("Status")]
        public virtual List<SelectListItem> ListaStatus { get; set; }
    }
}

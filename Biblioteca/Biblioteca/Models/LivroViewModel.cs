using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class LivroViewModel
    {

        [Key]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
    }
}
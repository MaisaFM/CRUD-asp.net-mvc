using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class PessoaViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public string Telefone { get; set; }
    }
}
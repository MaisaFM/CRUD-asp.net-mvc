using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Pessoa: EntidadeBase
    {
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public string Telefone { get; set; }
    }
}

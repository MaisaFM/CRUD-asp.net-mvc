using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Livro : EntidadeBase
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Emprestimo : EntidadeBase
    {
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public int LivroId { get; set; }
        public virtual Livro Livro { get; set; }

        public DateTime DtEmprestimo { get; set; }
        public DateTime DtDevolucao { get; set; }
    }
}

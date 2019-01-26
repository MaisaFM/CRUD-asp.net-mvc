using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class EmprestimoViewModel
    {
        public long Id { get; set; }

        public int PessoaId { get; set; }

        public int LivroId { get; set; }
        
        public DateTime DtEmprestimo { get; set; }
        public DateTime DtDevolucao { get; set; }
    }
}
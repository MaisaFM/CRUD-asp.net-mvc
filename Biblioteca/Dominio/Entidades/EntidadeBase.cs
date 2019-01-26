using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class EntidadeBase
    {
        public EntidadeBase()
        {
            if (Id > 0)
            {
                DataAtualizacao = DateTime.Now;
            }
            else
            {
                DataRegistro = DateTime.Now;
                Status = true;
                Deletado = false;
                DataAtualizacao = DateTime.Now;
            }

        }

        public long Id { get; set; }

        /// <summary>
        /// Data que foi Inserido o registro 
        /// </summary>
        public DateTime DataRegistro { get; set; }

        public DateTime DataAtualizacao { get; set; }

        /// <summary>
        /// Status ativo ou 
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Deletado true  para deletado false para não deletado
        /// </summary>
        public bool Deletado { get; set; }
    }
}

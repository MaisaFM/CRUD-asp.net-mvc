using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Data.Mapeameto
{
    internal class PessoaMapeamento : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMapeamento() { }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Data.Mapeameto
{
    internal class PessoaMapeamento : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMapeamento()
        {
            ToTable("Pessoa");
            HasKey(item => item.Id).Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(item => item.Nome).IsRequired();
            Property(item => item.DtNascimento).IsRequired();
            Property(item => item.Telefone).IsRequired();
        }
    }
}

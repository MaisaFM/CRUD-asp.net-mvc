using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;


namespace Entidades.Mapeamento
{
    internal class EmprestimoMapeamento : EntityTypeConfiguration<Emprestimo>
    {
        public EmprestimoMapeamento()
        {
            ToTable("Emprestimo");
            HasKey(item => item.Id).Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(item => item.PessoaId).IsRequired();
            Property(item => item.LivroId).IsRequired();
            Property(item => item.DtEmprestimo).IsRequired();
            Property(item => item.DtDevolucao).IsOptional();
        }
    }
}

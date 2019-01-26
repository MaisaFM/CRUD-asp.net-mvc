using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;


namespace Entidades.Mapeamento
{
    internal class LivroMapeamento : EntityTypeConfiguration<Livro>
    {
        public LivroMapeamento()
        {
            ToTable("Livro");
            HasKey(item => item.Id).Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(item => item.Nome).IsRequired();
            Property(item => item.Autor).IsRequired();
            Property(item => item.Ano).IsRequired();

            //HasRequired(item => item.Emprestimo).WithMany(item => item.Livros.).HasForeignKey(item => item.LivroId);
        }
    }
}

using System.Data.Entity;

namespace Data.Contexto
{
    public interface IDbContext
    {

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;


        int SaveChanges();
        void Dispose();

    }
}

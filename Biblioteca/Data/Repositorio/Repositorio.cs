using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Data.Contexto;
using Dominio;
using Dominio.Entidades;

namespace Data.Repositorio
{
    public class Repositorio<T> where T : EntidadeBase
    {
        private readonly DataContexto __contexto;

        public Repositorio(DataContexto _context)
        {
            this.__contexto = _context;
        }

        public IQueryable<T> Listar()
        {
            return __contexto.Set<T>().AsQueryable().OrderByDescending(item => item.Id);
        }

        public IQueryable<T> Listar(Expression<Func<T, bool>> predicate)
        {
            return __contexto.Set<T>().Where(predicate).Where(item => !item.Deletado).OrderByDescending(item => item.Id);
        }
        public int Contar(Expression<Func<T, bool>> predicate)
        {
            return __contexto.Set<T>().Count(predicate);
        }
        public IQueryable<T> FiltroPaginacao(Expression<Func<T, bool>> filter, out int total, out int totalpagina, int size = 50, int index = 1)
        {
            int skipCount = index == 0 ? 0 : (index - 1) * size;
            var resetSet = filter != null ? __contexto.Set<T>().Where<T>(filter).OrderByDescending(item => item.Id).Skip(skipCount).Take(size).ToList() : __contexto.Set<T>().OrderByDescending(item => item.Id).ToList().Take(10);
            total = filter != null ? __contexto.Set<T>().Where<T>(filter).Count() : __contexto.Set<T>().Count();
            totalpagina = (int)Math.Ceiling((double)total / size);
            return resetSet.AsQueryable().OrderByDescending(item => item.Id);
        }



        public bool Existe(Expression<Func<T, bool>> predicate)
        {
            return __contexto.Set<T>().Where(item => !item.Deletado).Count<T>(predicate) > 0;
        }

        public T Obter(params object[] keys)
        {
            this.__contexto.Configuration.ProxyCreationEnabled = true;
            return __contexto.Set<T>().Find(keys);
        }

        public T Obter(Expression<Func<T, bool>> predicate)
        {

            this.__contexto.Configuration.ProxyCreationEnabled = true;
            return __contexto.Set<T>().FirstOrDefault<T>(predicate);
        }

        public T Inserir(T objeto)
        {
            var newEntry = __contexto.Set<T>().Add(objeto);
            __contexto.SaveChanges();

            return newEntry;
        }

        public int Deletar(T t)
        {
            var item = __contexto.Set<T>().Find(t.Id);
            __contexto.Set<T>().Remove(item);

            return __contexto.SaveChanges();
        }

        public int Deletar(Expression<Func<T, bool>> predicate)
        {
            var objects = __contexto.Set<T>().Where(predicate).Where(item => !item.Deletado); ;

            foreach (var item in objects)
            {
                __contexto.Set<T>().Remove(item);
            }

            return __contexto.SaveChanges();
        }

        public void Deletar(long id, bool isLoop = false)
        {
            var objects = __contexto.Set<T>().Find(id);
            objects.Deletado = true;
            Editar(objects, isLoop);
        }

        public T Editar(T t, bool isLoop = false)
        {
            try
            {
                if (t == null)
                    throw new ArgumentNullException("entity");
                if (!isLoop)
                {
                    
                     __contexto.SaveChanges();
                }
                return t;
            }
            catch
            {
                throw;
            }
        }

        public void SaveChanges()
        {
            __contexto.SaveChanges();
        }

        public void ExecuteProcedure(string procedureCommand, params object[] sqlParams)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data.Contexto;
using Data.Repositorio;
using Dominio.Entidades;

namespace Servicos.Base
{
    public class ServicoBase<TEntity> : IServicoBase<TEntity> where TEntity : EntidadeBase
    {
        private readonly DataContexto _dbContext;
        private readonly Repositorio<TEntity> _repositorio;

        public ServicoBase()
        {
            _dbContext = new DataContexto();
            _repositorio = new Repositorio<TEntity>(_dbContext);
        }

        /// <summary>
        ///     Obtem  Todos os registros
        /// </summary>
        // <returns></returns>
        public IQueryable<TEntity> Listar()
        {
            return _repositorio.Listar();
        }

        /// <summary>
        ///     Obtem  Todos os registros atravez um expressao lambda
        /// </summary>
        /// <param name="expression">Expressao Lambda</param>
        /// <returns></returns>
        public IQueryable<TEntity> Listar(Expression<Func<TEntity, bool>> expression)
        {
            return _repositorio.Listar(expression);
        }
        public int Contar(Expression<Func<TEntity, bool>> expression)
        {
            return _repositorio.Contar(expression);
        }

        /// <summary>
        ///     Obtem os registro atravez de uma expressao lambda e parametros para a paginação no grid
        /// </summary>
        /// <param name="filter">Expressão lambda para o filtro</param>
        /// <param name="total">Total de registro encontrado </param>
        /// <param name="totalpagina">Total de paginas encontradas</param>
        /// <param name="orderBy">Tipo de ordenação</param>
        /// <param name="size">Quantos registros irão aparecer </param>
        /// <param name="index">pagina atual </param>
        /// <returns></returns>
        public IQueryable<TEntity> FiltroPaginacao(Expression<Func<TEntity, bool>> filter, out int total,
            out int totalpagina, int size = 50,
            int index = 0)
        {
            return _repositorio.FiltroPaginacao(filter, out total, out totalpagina, size, index);
        }

        /// <summary>
        ///     Obtem um regitro atravez de um Id
        /// </summary>
        /// <param name="id">Id do registro</param>
        /// <returns>um objeto do registro</returns>
        public TEntity Obter(long id)
        {
            return _repositorio.Obter(id);
        }

        /// <summary>
        ///     Obtem um regitro atravez de uma Expressao Lambda
        /// </summary>
        /// <param name="expression">Expressão Lambda do registro </param>
        /// <returns>um objeto do registro</returns>
        public TEntity Obter(Expression<Func<TEntity, bool>> expression)
        {
            return _repositorio.Obter(expression);
        }

        /// <summary>
        ///     Adiciona os valores do objeto no Contexto da aplicação
        /// </summary>
        /// <param name="entidade">valores do objeto </param>
        /// <returns></returns>
        public TEntity Inserir(TEntity entidade)
        {
            try
            {
                _repositorio.Inserir(entidade);
            }
            catch (Exception e)
            {
                //Inseriri serviço de erro 
                Console.WriteLine(e);
            }
            return entidade;
        }

        /// <summary>
        ///     Altera os valores do objeto no contexto da aplicação
        /// </summary>
        /// <param name="entidade">valrores do objeto </param>
        /// <returns></returns>
        public TEntity Editar(TEntity entidade, bool isLoop = false)
        {
            _repositorio.Editar(entidade, isLoop);
            return entidade;
        }

        /// <summary>
        ///     Deleta um registro do contexto da aplicação
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(long id, bool isLoop = false)
        {
            _repositorio.Deletar(id, isLoop);
        }

        public void DeletarMultiplos(List<TEntity> entidades)
        {
            foreach (var entidade in entidades)
            {
                _repositorio.Deletar(entidade);
            }
        }
        /// <summary>
        ///     Deleta um registro do contexto da aplicação
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(TEntity entidade)
        {
            _repositorio.Deletar(entidade);

        }

        public void Deletar(Expression<Func<TEntity, bool>> expression)
        {
            _repositorio.Deletar(expression);
        }

        /// <summary>
        ///     Verifica se existe um registro atravez de uma expressao lambda
        /// </summary>
        /// <param name="expression">Expressao </param>
        /// <returns></returns>
        public bool Existe(Expression<Func<TEntity, bool>> expression)
        {
            return _repositorio.Existe(expression);
        }

        public void Paginacao(IList<TEntity> list, out int total, out int totalpagina, int size = 50, int index = 0)
        {
            total = list.Count();
            totalpagina = (int)Math.Ceiling((double)total / size);
        }

        public void SaveChanges()
        {
            _repositorio.SaveChanges();
        }
    }
}
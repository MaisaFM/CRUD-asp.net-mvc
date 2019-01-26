using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dominio.Entidades;

namespace Servicos.Base
{
    public interface IServicoBase<TEntity> where TEntity : EntidadeBase
    {
        /// <summary>
        ///     Obtem  Todos os registros
        /// </summary>
        // <returns></returns>
        IQueryable<TEntity> Listar();

        /// <summary>
        ///     Obtem  Todos os registros atravez um expressao lambda
        /// </summary>
        /// <param name="expression">Expressao Lambda</param>
        /// <returns></returns>
        IQueryable<TEntity> Listar(Expression<Func<TEntity, bool>> expression);

        int Contar(Expression<Func<TEntity, bool>> expression);

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
        IQueryable<TEntity> FiltroPaginacao(Expression<Func<TEntity, bool>> filter, out int total, out int totalpagina,
            int size = 50,
            int index = 0);

        /// <summary>
        ///     Obtem um regitro atravez de um Id
        /// </summary>
        /// <param name="id">Id do registro</param>
        /// <returns>um objeto do registro</returns>
        TEntity Obter(long id);

        /// <summary>
        ///     Obtem um regitro atravez de uma Expressao Lambda
        /// </summary>
        /// <param name="expression">Expressão Lambda do registro </param>
        /// <returns>um objeto do registro</returns>
        TEntity Obter(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        ///     Adiciona os valores do objeto no Contexto da aplicação
        /// </summary>
        /// <param name="entidade">valores do objeto </param>
        /// <returns></returns>
        TEntity Inserir(TEntity entidade);

        /// <summary>
        ///     Altera os valores do objeto no contexto da aplicação
        /// </summary>
        /// <param name="entidade">valrores do objeto </param>
        /// <returns></returns>
        TEntity Editar(TEntity entidade, bool isLoop = false);

        /// <summary>
        ///     Deleta um registro do banco da aplicação
        /// </summary>
        /// <param name="entidade"></param>
        void Deletar(TEntity entidade);

        void DeletarMultiplos(List<TEntity> t);

        void Deletar(long id, bool isLoop = false);

        void Deletar(Expression<Func<TEntity, bool>> expression);

        bool Existe(Expression<Func<TEntity, bool>> expression);

        void Paginacao(IList<TEntity> list, out int total, out int totalpagina,
            int size = 50,
            int index = 0);
        void SaveChanges();
    }
}
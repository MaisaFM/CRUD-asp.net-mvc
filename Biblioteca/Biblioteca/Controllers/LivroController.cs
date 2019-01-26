using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteca.Models;
using Dominio.Entidades;
using Servicos.Base;

namespace Biblioteca.Controllers
{
    public class LivroController : Controller
    {
        private readonly IServicoBase<Livro> _livroService = new ServicoBase<Livro>();

        // GET: Livro
        public ActionResult Create()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return RedirectToAction("Create");
        //}


        [HttpPost]
        public ActionResult Create(LivroViewModel livro)
        {
            Livro l = new Livro();
            l.Id = livro.Id;
            l.Nome = livro.Nome;
            l.Ano = livro.Ano;
            l.Autor = livro.Autor;
            _livroService.Inserir(l);
            return RedirectToAction("Create");
        }

        public ActionResult ListarLivros()
        {
            IList<LivroViewModel> livros = new List<LivroViewModel>();
            var l = _livroService.Listar();
            if (l != null)
            {
                foreach (Livro lv in l)
                {
                    LivroViewModel v = new LivroViewModel();
                    v.Id = lv.Id;
                    v.Autor = lv.Autor;
                    v.Ano = lv.Ano;
                    v.Nome = lv.Nome;
                    
                    livros.Add(v);
                }
            }

            return View(livros);
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Livro l = new Livro();
            l = _livroService.Obter(id);

            if (l == null)
            {
                return HttpNotFound();
            }

            LivroViewModel lm = new LivroViewModel();
            lm.Id = l.Id;
            lm.Ano = l.Ano;
            lm.Autor = l.Autor;
            lm.Nome = l.Nome;

            return View(lm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LivroViewModel livro)
        {
            var l = _livroService.Obter(livro.Id);
            l.Id = livro.Id;
            l.Ano = livro.Ano;
            l.Autor = livro.Autor;
            l.Nome = livro.Nome;
            _livroService.Editar(l);
            //LivroViewModel lm = new LivroViewModel();
            //lm.Id = l.Id;
            //lm.Ano = l.Ano;
            //lm.Autor = l.Autor;
            //lm.Nome = l.Nome;
            return RedirectToAction("ListarLivros");
        }

        public ActionResult Delete(LivroViewModel livro)
        {
            Livro l = new Livro();
            l.Id = livro.Id;
            l.Nome = livro.Nome;
            l.Ano = livro.Ano;
            l.Autor = livro.Autor;
            _livroService.Deletar(l);
            return RedirectToAction("ListarLivros");
        }

    }
}
using Biblioteca.Models;
using Dominio.Entidades;
using Servicos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.Controllers
{
    public class EmprestimoController : Controller
    {

        private readonly IServicoBase<Emprestimo> _emprestimoService = new ServicoBase<Emprestimo>();

        // GET: Emprestimo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar(EmprestimoViewModel emprestimo)
        {
            Emprestimo e = new Emprestimo();
            e.DtDevolucao = emprestimo.DtDevolucao;
            e.DtEmprestimo = emprestimo.DtEmprestimo;
            e.LivroId = emprestimo.LivroId;
            e.PessoaId = emprestimo.PessoaId;
            _emprestimoService.Inserir(e);
            return RedirectToAction("Cadastrar");
        }

        public ActionResult ListarEmprestimos()
        {
            var e = _emprestimoService.Listar();
            return View("Index", e);
        }
    }
}
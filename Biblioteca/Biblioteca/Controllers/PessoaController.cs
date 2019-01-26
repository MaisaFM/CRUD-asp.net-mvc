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
    public class PessoaController : Controller
    {
        private readonly IServicoBase<Pessoa> _pessoaService = new ServicoBase<Pessoa>();

        // GET: Pessoa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar(PessoaViewModel pessoa)
        {
            Pessoa p = new Pessoa();
            p.Nome = pessoa.Nome;
            p.DtNascimento = pessoa.DtNascimento;
            p.Telefone = pessoa.Telefone;
            _pessoaService.Inserir(p);
            return RedirectToAction("Cadastrar");
        }

        public ActionResult ListarPessoas()
        {     
            var p = _pessoaService.Listar();
            return View("Index", p);
        }
    }
}
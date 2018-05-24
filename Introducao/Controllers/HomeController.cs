using Introducao.Models;
using System.Web.Mvc;

namespace Introducao.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var pessoa = new Pessoa
            {
                pessoaId = 1,
                nome = "Vitor Hugo",
                tipo = "Administrador"
            };

            var pessoa2 = new Pessoa
            {
                pessoaId = 2,
                nome = "Brenda Gabriela",
                tipo = "Administrador"
            };

            // para usar ViewData os nomes dos atributos do array ViewData devem ser os mesmos do atributos do objeto pessoa
            ViewData["pessoaId"] = pessoa.pessoaId;
            ViewData["nome"] = pessoa.nome;
            ViewBag.tipoPessoa = pessoa.tipo; // O ViewBag pode ter qualquer nome

            return View(pessoa2); // dessa maneira se passa o model com View Tipada
        }

        public ActionResult Contatos()
        {
            return View();
        }

        [HttpPost] // Esse sufixo sempre será usado quando se tratar de uma rota 'POST'
        public ActionResult Lista(int pessoaId, string nome, string tipo)
        {
            ViewData["pessoaId"] = pessoaId;
            ViewData["nome"] = nome;
            ViewData["tipo"] = tipo;

            return View();
        }

        public ActionResult ListaGet(int pessoaId, string nome, string tipo)
        {
            ViewData["pessoaId"] = pessoaId;
            ViewData["nome"] = nome;
            ViewData["tipo"] = tipo;
            return View();
        }

        // nesse caso , quando se usa form colletion as informações são armazenadas em array e podem ser acessadas por seus nomes
        public ActionResult ListaFormCollection(FormCollection formulario)
        {
            ViewData["pessoaId"] = formulario["pessoaId"];
            ViewData["nome"] = formulario["nome"];
            ViewData["tipo"] = formulario["tipo"];
            return View();
        }

        // no caso da view tipada não é necessário atribuir a viewbags ou viewdatas o objeto pessoa já recebe todos os parametros do formulários em seus atributos
        // justamente porque os parametros do formulário correpondem aos atributos do objeto pessoa
        // então o objeto é informado direto na view
        public ActionResult ListaTipada(Pessoa pessoa)
        {
            return View(pessoa);
        }
    }
}
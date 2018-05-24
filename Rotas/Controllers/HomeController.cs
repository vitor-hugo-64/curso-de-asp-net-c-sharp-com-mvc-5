using Rotas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rotas.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnumerable<Noticia> todasAsNoticias; // essa variável será passada pela View Tipada

        public HomeController()
        {
            todasAsNoticias = new Noticia().TodasAsNoticias().OrderByDescending(x => x.Data); // ira pegar todas as noticias da do IEnumerable e ira armazenar no atributo em ordem descendente com base na data das noticias
        }

        public ActionResult Index()
        {
            var ultimasNoticias = todasAsNoticias.Take(3); // pega os tres primeiros valores da variavel todasAsNoticias
            var todasAsCategorias = todasAsNoticias.Select(x => x.Categoria).Distinct(); // pega todas as categorias que são diferente
            ViewBag.todasAsCategorias = todasAsCategorias;
            return View(ultimasNoticias); // aqui a variável é passada pela view tipada
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TodasAsNoticias()
        {
            return View(todasAsNoticias); // aqui a variável é passada pela view tipada
        }

        public ActionResult MostraNoticia(int noticiaId, string titulo, string categoria) // aqui será recebidos esses paramentros para definir o que será mostrado
        {
            return View(todasAsNoticias.FirstOrDefault(x => x.NoticiaId == noticiaId)); // nessa parte será passado o id da noticia que foi clicado, e isso fara um  filtro para mostrar somente o id da noticia que está sendo informado
        }

        public ActionResult MostraCategoria(string categoria)
        {
            // esssa próxima linha verifica se a categoria informada é igual a alguma categoria do banco, se for ela vai listar na variável
            var categoriaEspecifica = todasAsNoticias.Where(x => x.Categoria.ToLower() == categoria.ToLower()).ToList();
            ViewBag.Categoria = categoria; // viewbag vai receber o categoria especifica
            return View(categoriaEspecifica); // iforma a categoria especifica
        }
    }
}
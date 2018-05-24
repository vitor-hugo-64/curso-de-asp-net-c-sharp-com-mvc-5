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
        private readonly IEnumerable<Noticia> todasAsNoticias;

        public HomeController()
        {
            todasAsNoticias = new Noticia().TodasAsNoticias().OrderByDescending(x => x.Data); // ira pegar todas as noticias da do IEnumerable e ira armazenar no atributo em ordem descendente com base na data das noticias
        }

        public ActionResult Index()
        {
            var ultimasNoticias = todasAsNoticias.Take(3); // pega os tres primeiros valores da variavel todasAsNoticias
            var todasAsCategorias = todasAsNoticias.Select(x => x.Categoria).Distinct(); // pega todas as categorias que são diferente
            ViewBag.todasAsCategorias = todasAsCategorias;
            return View(ultimasNoticias);
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
    }
}
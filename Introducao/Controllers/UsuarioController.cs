using Introducao.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;

namespace Introducao.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Usuario()
        {
            var usuario = new Usuario();
            return View(usuario);
        }

        [HttpPost] // Metodo POST
        public ActionResult Usuario(Usuario usuario)
        {
            if (ModelState.IsValid) // Verifica se o formulário foi validado
            {
                return View("Resultado", usuario); // se for validado sera direcionado para a View Resultado e os dados do objeto serão setados na View
            }
            return View(usuario); // Caso Não Entre no if será redirecinado de volta para a página
        }

        public ActionResult Resultado(Usuario usuario)
        {
            return View(usuario);
        }

        public ActionResult LoginUnico(string login) // Ira verificar se um determinado login já existe
        {
            var bdExemplo = new Collection<string> // array que será usado como banco de dados ficticio
            {
                "Hugo",
                "Freitas",
                "Paula"
            };

            // verifica se os dados do ''banco'' são iguais aos informados, se for é porque já existe esse login então ele retornara um erro
            return Json(bdExemplo.All(x => x.ToLower() != login.ToLower()), JsonRequestBehavior.AllowGet);
        }
    }
}
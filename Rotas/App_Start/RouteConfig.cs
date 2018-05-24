using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Rotas
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute( // Rota Nova
                name:"Todas As Noticias", // Nome Definido Para A Url
                url:"noticias/", // forma com a rota sera chamada na url //aconselhado colocar a barra depois do nome, caso tenha algo depois não da erro
                defaults: new { controller = "Home", action = "TodasAsNoticias"} // aqui é informado o Model e a função que será atribuída a rota
            );

            routes.MapRoute( // Rota Nova
                name: "Categoria Especifica", // Nome Definido Para A Url
                url: "noticias/{categoria}", // quando a action for chamada será necessário passar um parametro para ela, então é colocado entre chaves o parametro da url
                defaults: new { controller = "Home", action = "MostraCategoria" } // aqui é informado o Model e a função que será atribuída a rota
            );

            routes.MapRoute( // Rota Nova
                name: "Mostra Noticia", // Nome Definido Para A Url
                url: "noticias/{categoria}/{titulo}-{noticiaId}", // quando a action for chamada será necessário passar um parametro para ela, então é colocado entre chaves o parametro da url
                defaults: new { controller = "Home", action = "MostraNoticia" } // aqui é informado o Model e a função que será atribuída a rota
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

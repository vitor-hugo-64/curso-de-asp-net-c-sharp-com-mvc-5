using System.Web;
using System.Web.Optimization;

namespace Bundle
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true; // essa linha abilita para que o bundle use todos os arquivos que estão linkados abaixo

            bundles.Add(new ScriptBundle("~/comum").IncludeDirectory("~/Scripts/comum", "*.js", true));

            // Definir ordem dos arquivos a serem chamados
            var ordem = new BundleFileSetOrdering("MeuScript");
            ordem.Files.Add("setup.js");
            ordem.Files.Add("display.js");
            bundles.FileSetOrderList.Insert( 0, ordem);

            bundles.IgnoreList.Ignore("*.dbg.js"); // assim é ignorado todos os arquivos que possuem essa sub extensão. Essa sub extensão pode ser criada pelo próprio programador na hora de editar o nome do arquivo

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}

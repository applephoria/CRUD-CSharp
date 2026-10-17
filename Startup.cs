using CRUD.Repositories;
using CRUD.Views;

namespace CRUD
{
    internal static class Startup
    {
        public static MenuConsole Inicializar()
        {
            IPessoaRepository repositorioPessoas = new PessoaRepository();

            MenuConsole menu = new MenuConsole(repositorioPessoas);

            return menu;
        }
    }
}

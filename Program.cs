using CRUD.Views;

namespace CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuConsole menu = Startup.Inicializar();

            menu.ExibirMenu();
        }
    }
}
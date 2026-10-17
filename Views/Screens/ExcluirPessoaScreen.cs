using System;
using CRUD.Models;
using CRUD.Repositories;

namespace CRUD.Views.Screens
{
    internal class ExcluirPessoaScreen
    {
        internal static void Executar(IPessoaRepository repositorioPessoas)
        {
            try
            {
                if (Console.IsOutputRedirected == false)
                {
                    Console.Clear();
                }
                Console.WriteLine("================================");
                Console.WriteLine("    EXCLUIR PESSOA POR ID       ");
                Console.WriteLine("================================");

                Console.Write("Digite o ID da pessoa que deseja excluir: ");
                string entradaId = Console.ReadLine();
                int idParaExcluir = int.Parse(entradaId);

                Pessoa pessoaEncontrada = repositorioPessoas.ObterPorId(idParaExcluir);

                if (pessoaEncontrada == null)
                {
                    Console.WriteLine("\nNenhuma pessoa encontrada com esse ID!");
                }
                else
                {
                    repositorioPessoas.Excluir(idParaExcluir);
                    Console.WriteLine("\n" + pessoaEncontrada.Nome + " (ID: " + idParaExcluir + ") foi removido(a) com sucesso!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nErro ao excluir: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nPressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
        }
    }
}

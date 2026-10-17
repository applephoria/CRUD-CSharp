using System;
using System.Collections.Generic;
using CRUD.Models;
using CRUD.Repositories;

namespace CRUD.Views.Screens
{
    internal class ListarPessoasScreen
    {
        internal static void Executar(IPessoaRepository repositorioPessoas)
        {
            if (Console.IsOutputRedirected == false)
            {
                Console.Clear();
            }
            Console.WriteLine("=================================");
            Console.WriteLine("  LISTA DE PESSOAS CADASTRADAS   ");
            Console.WriteLine("=================================");

            List<Pessoa> listaPessoas = repositorioPessoas.ObterTodos();

            int totalPessoas = listaPessoas.Count;

            if (totalPessoas == 0)
            {
                Console.WriteLine("Nenhuma pessoa cadastrada ate o momento.");
            }
            else
            {
                foreach (Pessoa pessoa in listaPessoas)
                {
                    Console.WriteLine("----------------------------------");
                    pessoa.Apresentar();
                }
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Total de pessoas: " + totalPessoas);
            }

            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
        }
    }
}

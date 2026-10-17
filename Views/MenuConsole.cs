using System;
using CRUD.Repositories;
using CRUD.Views.Screens;

namespace CRUD.Views
{
    internal class MenuConsole
    {
        private readonly IPessoaRepository _repositorioPessoas;

        public MenuConsole(IPessoaRepository repositorioPessoas)
        {
            _repositorioPessoas = repositorioPessoas;
        }

        public void ExibirMenu()
        {
            bool executando = true;

            while (executando == true)
            {
                if (Console.IsOutputRedirected == false)
                {
                    Console.Clear();
                }
                Console.WriteLine("=================================");
                Console.WriteLine("    SISTEMA ESCOLAR DE ALUNOS    ");
                Console.WriteLine("=================================");
                Console.WriteLine("1 - Cadastrar Novo Aluno");
                Console.WriteLine("2 - Cadastrar Novo Professor");
                Console.WriteLine("3 - Listar Todas as Pessoas");
                Console.WriteLine("4 - Excluir Pessoa por ID");
                Console.WriteLine("5 - Atualizar Pessoa por ID");
                Console.WriteLine("0 - Sair do Sistema");
                Console.WriteLine("=================================");
                Console.Write("Escolha uma opcao: ");

                string opcao = Console.ReadLine();

                if (opcao == null)
                {
                    break;
                }

                switch (opcao)
                {
                    case "1":
                        CadastrarAlunoScreen.Executar(_repositorioPessoas);
                        break;
                    case "2":
                        CadastrarProfessorScreen.Executar(_repositorioPessoas);
                        break;
                    case "3":
                        ListarPessoasScreen.Executar(_repositorioPessoas);
                        break;
                    case "4":
                        ExcluirPessoaScreen.Executar(_repositorioPessoas);
                        break;
                    case "5":
                        AtualizarPessoaScreen.Executar(_repositorioPessoas);
                        break;
                    case "0":
                        executando = false;
                        Console.WriteLine("\nSaindo do sistema... Ate logo!");
                        break;
                    default:
                        Console.WriteLine("\nOpcao invalida! Pressione ENTER para tentar novamente.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
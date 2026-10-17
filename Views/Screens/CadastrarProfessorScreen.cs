using System;
using System.Globalization;
using CRUD.Models;
using CRUD.Repositories;

namespace CRUD.Views.Screens
{
    internal class CadastrarProfessorScreen
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
                Console.WriteLine("  NOVO CADASTRO DE PROFESSOR    ");
                Console.WriteLine("================================");

                Professor novoProfessor = new Professor();

                Console.Write("Digite o ID: ");
                string entradaId = Console.ReadLine();
                int idDigitado = int.Parse(entradaId);
                novoProfessor.Id = idDigitado;

                Pessoa pessoaEncontrada = repositorioPessoas.ObterPorId(novoProfessor.Id);

                if (pessoaEncontrada != null)
                {
                    Console.WriteLine("\nJa existe uma pessoa cadastrada com o ID " + novoProfessor.Id + "!");
                    return;
                }

                Console.Write("Digite o Nome: ");
                string nomeDigitado = Console.ReadLine();
                novoProfessor.Nome = nomeDigitado;

                Console.Write("Digite a Idade: ");
                string entradaIdade = Console.ReadLine();
                int idadeDigitada = int.Parse(entradaIdade);
                novoProfessor.Idade = idadeDigitada;

                Console.Write("Digite a Disciplina: ");
                string disciplinaDigitada = Console.ReadLine();
                novoProfessor.Disciplina = disciplinaDigitada;

                Console.Write("Digite o Salario (Ex: 7.822,00): ");
                string entradaSalario = Console.ReadLine();
                double salarioDigitado = double.Parse(entradaSalario, CultureInfo.GetCultureInfo("pt-BR"));
                novoProfessor.Salario = salarioDigitado;

                repositorioPessoas.Adicionar(novoProfessor);

                Console.WriteLine("\nProfessor adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nErro ao cadastrar professor: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nPressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
        }
    }
}

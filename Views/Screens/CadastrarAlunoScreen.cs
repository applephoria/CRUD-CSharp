using System;
using System.Globalization;
using CRUD.Models;
using CRUD.Repositories;

namespace CRUD.Views.Screens
{
    internal class CadastrarAlunoScreen
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
                Console.WriteLine("    NOVO CADASTRO DE ALUNO      ");
                Console.WriteLine("================================");

                Aluno novoAluno = new Aluno();

                Console.Write("Digite o ID: ");
                string entradaId = Console.ReadLine();
                int idDigitado = int.Parse(entradaId);
                novoAluno.Id = idDigitado;

                Pessoa pessoaEncontrada = repositorioPessoas.ObterPorId(novoAluno.Id);

                if (pessoaEncontrada != null)
                {
                    Console.WriteLine("\nJa existe uma pessoa cadastrada com o ID " + novoAluno.Id + "!");
                    return;
                }

                Console.Write("Digite o Nome: ");
                string nomeDigitado = Console.ReadLine();
                novoAluno.Nome = nomeDigitado;

                Console.Write("Digite a Idade: ");
                string entradaIdade = Console.ReadLine();
                int idadeDigitada = int.Parse(entradaIdade);
                novoAluno.Idade = idadeDigitada;

                Console.Write("Digite a Nota (Ex: 4.7 ou 9.5): ");
                string entradaNota = Console.ReadLine();
                double notaDigitada = double.Parse(entradaNota, CultureInfo.InvariantCulture);
                novoAluno.Nota = notaDigitada;

                repositorioPessoas.Adicionar(novoAluno);

                Console.WriteLine("\nAluno adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nErro ao cadastrar aluno: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nPressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
        }
    }
}
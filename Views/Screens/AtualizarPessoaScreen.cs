using System;
using System.Globalization;
using CRUD.Models;
using CRUD.Repositories;

namespace CRUD.Views.Screens
{
    internal class AtualizarPessoaScreen
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
                Console.WriteLine("   ATUALIZAR PESSOA POR ID      ");
                Console.WriteLine("================================");

                Console.Write("Digite o ID da pessoa que deseja atualizar: ");

                int idParaAtualizar = default;
                bool idValido = false;

                while (idValido == false)
                {
                    string entradaId = Console.ReadLine();

                    bool conseguiuConverter = int.TryParse(entradaId, out idParaAtualizar);

                    bool numeroPositivo = idParaAtualizar > 0;

                    if (conseguiuConverter == true && numeroPositivo == true)
                    {
                        idValido = true;
                    }
                    else
                    {
                        Console.WriteLine("\nID invalido! O ID deve ser um numero inteiro e maior que zero.");
                        Console.Write("Por favor, digite o ID novamente: ");
                    }
                }

                Pessoa pessoaEncontrada = repositorioPessoas.ObterPorId(idParaAtualizar);

                if (pessoaEncontrada == null)
                {
                    Console.WriteLine("\nNenhuma pessoa encontrada com esse ID!");
                }
                else
                {
                    Console.WriteLine("\nDados atuais de " + pessoaEncontrada.Nome + " (ID: " + idParaAtualizar + "):");
                    pessoaEncontrada.Apresentar();

                    Console.WriteLine("\n=== DIGITE OS NOVOS DADOS ===");

                    Console.Write("Digite o novo nome: ");
                    string novoNome = Console.ReadLine();
                    pessoaEncontrada.Nome = novoNome;

                    Console.Write("Digite a nova idade: ");
                    string entradaNovaIdade = Console.ReadLine();
                    int novaIdade = int.Parse(entradaNovaIdade);
                    pessoaEncontrada.Idade = novaIdade;

                    if (pessoaEncontrada is Aluno aluno)
                    {
                        Console.Write("Digite a nova nota (Ex: 4.7 ou 9.5): ");
                        string entradaNovaNota = Console.ReadLine();
                        double novaNota = double.Parse(entradaNovaNota, CultureInfo.InvariantCulture);
                        aluno.Nota = novaNota;
                    }
                    else if (pessoaEncontrada is Professor professor)
                    {
                        Console.Write("Digite a nova disciplina: ");
                        string novaDisciplina = Console.ReadLine();
                        professor.Disciplina = novaDisciplina;

                        Console.Write("Digite o novo salario (Ex: 7.822,00): ");
                        string entradaNovoSalario = Console.ReadLine();
                        double novoSalario = double.Parse(entradaNovoSalario, CultureInfo.GetCultureInfo("pt-BR"));
                        professor.Salario = novoSalario;
                    }

                    repositorioPessoas.Atualizar(pessoaEncontrada);
                    Console.WriteLine("\nDados do ID " + idParaAtualizar + " atualizados com sucesso!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nErro ao atualizar: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nPressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
        }
    }
}

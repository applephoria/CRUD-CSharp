using System;
using System.Collections.Generic;
using CRUD.Models;

namespace CRUD.Repositories
{
    internal class PessoaRepository : IPessoaRepository
    {
        private List<Pessoa> _listaPessoas = new List<Pessoa>();

        public void Adicionar(Pessoa pessoa)
        {
            _listaPessoas.Add(pessoa);
        }

        public List<Pessoa> ObterTodos()
        {
            return _listaPessoas;
        }

        public Pessoa ObterPorId(int id)
        {
            foreach (Pessoa pessoa in _listaPessoas)
            {
                if (pessoa.Id == id)
                {
                    return pessoa;
                }
            }

            return null;
        }

        public void Excluir(int id)
        {
            Pessoa pessoaParaRemover = ObterPorId(id);

            if (pessoaParaRemover != null)
            {
                _listaPessoas.Remove(pessoaParaRemover);
            }
        }

        public void Atualizar(Pessoa pessoaAtualizada)
        {
            Pessoa pessoaExistente = ObterPorId(pessoaAtualizada.Id);

            if (pessoaExistente != null)
            {
                pessoaExistente.Nome = pessoaAtualizada.Nome;
                pessoaExistente.Idade = pessoaAtualizada.Idade;

                if (pessoaExistente is Aluno alunoExistente && pessoaAtualizada is Aluno alunoNovo)
                {
                    alunoExistente.Nota = alunoNovo.Nota;
                }
                else if (pessoaExistente is Professor professorExistente && pessoaAtualizada is Professor professorNovo)
                {
                    professorExistente.Disciplina = professorNovo.Disciplina;
                    professorExistente.Salario = professorNovo.Salario;
                }
            }
        }
    }
}
using System.Collections.Generic;
using CRUD.Models;

namespace CRUD.Repositories
{
    internal interface IPessoaRepository
    {
        void Adicionar(Pessoa pessoa);

        List<Pessoa> ObterTodos();

        Pessoa ObterPorId(int id);

        void Excluir(int id);

        void Atualizar(Pessoa pessoa);
    }
}

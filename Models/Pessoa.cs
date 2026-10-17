using System;

namespace CRUD.Models
{
    internal abstract class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public abstract void Apresentar();
    }
}

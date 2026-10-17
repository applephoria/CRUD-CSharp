using System;
using System.Globalization;

namespace CRUD.Models
{
    internal class Aluno : Pessoa
    {
        public double Nota { get; set; }

        public override void Apresentar()
        {
            string notaFormatada = Nota.ToString("0.0", CultureInfo.InvariantCulture);
            Console.WriteLine("ALUNO: " + Nome + " | ID: " + Id + " | Idade: " + Idade + " | Nota: " + notaFormatada);
        }
    }
}

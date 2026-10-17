using System;
using System.Globalization;

namespace CRUD.Models
{
    internal class Professor : Pessoa
    {
        public string Disciplina { get; set; }
        public double Salario { get; set; }

        public override void Apresentar()
        {
            string salarioFormatado = Salario.ToString("N2", CultureInfo.GetCultureInfo("pt-BR"));
            Console.WriteLine("PROFESSOR: " + Nome + " | ID: " + Id + " | Idade: " + Idade + " | Disciplina: " + Disciplina + " | Salario: R$ " + salarioFormatado);
        }
    }
}

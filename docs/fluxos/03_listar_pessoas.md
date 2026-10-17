# 🔀 Fluxo de Dados: Opção 3 - Listar Todas as Pessoas

* **Operação CRUD:** Read (Leitura e Consulta)
* **Componente Responsável:** `Views/Screens/ListarPessoasScreen.cs`
* **Conceito Chave:** Polimorfismo e Ligação Tardia (*Late Binding*)

---

## 📊 Fluxograma de Execução e Apresentação Polimórfica

```mermaid
flowchart TD
    START(["Início: ListarPessoasScreen.Executar()"]) --> CLEAR["Limpar Console se não redirecionado"]
    CLEAR --> HEADER["Exibir Cabeçalho: LISTA DE PESSOAS CADASTRADAS"]
    
    HEADER --> FETCH["Buscar coleção: listaPessoas = repositorioPessoas.ObterTodos()"]
    FETCH --> COUNT["Calcular totalPessoas = listaPessoas.Count"]

    COUNT --> CHECK_EMPTY{"totalPessoas == 0?"}

    CHECK_EMPTY -->|"Sim (Vazia)"| SHOW_EMPTY["Exibir: Nenhuma pessoa cadastrada ate o momento."]
    SHOW_EMPTY --> WAIT_KEY

    CHECK_EMPTY -->|"Não (Existem Registros)"| LOOP_START["Iniciar loop: foreach (Pessoa pessoa in listaPessoas)"]

    LOOP_START --> CALL_POLY["Chamar método polimórfico: pessoa.Apresentar()"]

    CALL_POLY --> RESOLVE_TYPE{"Tipo Concreto em Tempo de Execução?"}

    RESOLVE_TYPE -->|"Aluno"| EXEC_ALUNO["Executa Aluno.Apresentar()\nFormata Nota com InvariantCulture (ex: 9.5)"]
    RESOLVE_TYPE -->|"Professor"| EXEC_PROF["Executa Professor.Apresentar()\nFormata Salário com pt-BR N2 (ex: R$ 7.822,00)"]

    EXEC_ALUNO --> NEXT_ITEM{"Mais itens na lista?"}
    EXEC_PROF --> NEXT_ITEM

    NEXT_ITEM -->|"Sim"| LOOP_START
    NEXT_ITEM -->|"Não"| SHOW_TOTAL["Exibir: Total de pessoas: totalPessoas"]

    SHOW_TOTAL --> WAIT_KEY[/"Exibir: Pressione ENTER para voltar ao menu..."/]
    WAIT_KEY --> READ_KEY[/"Console.ReadLine()"/]
    READ_KEY --> END(["Fim: Retorna ao MenuConsole"])
```

---

## 🎭 O Polimorfismo em Ação no Código

Observe a elegância do trecho em C#:

```csharp
foreach (Pessoa pessoa in listaPessoas)
{
    Console.WriteLine("----------------------------------");
    pessoa.Apresentar();
}
```

O método `ListarPessoasScreen` **não precisa saber** se a pessoa é um aluno ou um professor, nem precisa fazer `if/else` para descobrir. Cada objeto sabe exatamente como se apresentar:

| Entidade | Implementação de `Apresentar()` | Exemplo de Saída no Console |
| :--- | :--- | :--- |
| **`Aluno`** | `Nota.ToString("0.0", CultureInfo.InvariantCulture)` | `ALUNO: Lucas | ID: 1 | Idade: 20 | Nota: 9.5` |
| **`Professor`** | `Salario.ToString("N2", CultureInfo.GetCultureInfo("pt-BR"))` | `PROFESSOR: Carlos | ID: 2 | Idade: 45 | Disciplina: Matemática | Salario: R$ 7.822,00` |

---

## 🎯 Destaques de Engenharia
1. **Extensibilidade (Princípio Aberto/Fechado - OCP)**: Se amanhã for criada uma nova classe `Coordenador : Pessoa`, a tela de listagem continuará funcionando sem precisar alterar uma única linha de código.
2. **Desacoplamento Visual**: Toda a lógica de representação em texto do modelo reside dentro do próprio modelo.

---

[⬅️ Voltar para o Índice de Fluxos](./README.md) | [🏠 Voltar para a Documentação Central](../README.md)

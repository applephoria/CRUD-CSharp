# 🔀 Fluxo de Dados: Opção 2 - Cadastrar Novo Professor

* **Operação CRUD:** Create (Criação)
* **Componente Responsável:** `Views/Screens/CadastrarProfessorScreen.cs`
* **Entidade Manipulada:** `Models/Professor.cs`

---

## 📊 Fluxograma de Execução e Dados

```mermaid
flowchart TD
    START(["Início: CadastrarProfessorScreen.Executar()"]) --> CLEAR["Limpar Console se não redirecionado"]
    CLEAR --> HEADER["Exibir Cabeçalho: NOVO CADASTRO DE PROFESSOR"]
    HEADER --> INSTANTIATE["Criar nova instância: novoProfessor = new Professor()"]
    
    INSTANTIATE --> READ_ID[/"Ler entradaId (Console.ReadLine)"/]
    READ_ID --> PARSE_ID["Converter para int: int.Parse(entradaId)"]
    PARSE_ID --> ASSIGN_ID["novoProfessor.Id = idDigitado"]

    ASSIGN_ID --> CHECK_EXISTS{"repositorioPessoas.ObterPorId(novoProfessor.Id) != null?"}
    
    CHECK_EXISTS -->|"Sim (ID Duplicado)"| WARN_DUPLICATE["Exibir: Já existe pessoa com este ID!"]
    WARN_DUPLICATE --> FINALLY_BLOCK

    CHECK_EXISTS -->|"Não (ID Disponível)"| READ_NOME[/"Ler entradaNome (Console.ReadLine)"/]
    READ_NOME --> ASSIGN_NOME["novoProfessor.Nome = nomeDigitado"]

    ASSIGN_NOME --> READ_IDADE[/"Ler entradaIdade (Console.ReadLine)"/]
    READ_IDADE --> PARSE_IDADE["Converter para int: int.Parse(entradaIdade)"]
    PARSE_IDADE --> ASSIGN_IDADE["novoProfessor.Idade = idadeDigitada"]

    ASSIGN_IDADE --> READ_DISCIPLINA[/"Ler entradaDisciplina (Console.ReadLine)"/]
    READ_DISCIPLINA --> ASSIGN_DISC["novoProfessor.Disciplina = disciplinaDigitada"]

    ASSIGN_DISC --> PROMPT_SALARIO[/"Exibir: Digite o Salario (Ex: 7.822,00): "/]
    PROMPT_SALARIO --> READ_SALARIO[/"Ler entradaSalario (Console.ReadLine)"/]
    READ_SALARIO --> PARSE_SALARIO["Converter via pt-BR: double.Parse(entradaSalario, CultureInfo.GetCultureInfo('pt-BR'))"]
    PARSE_SALARIO --> ASSIGN_SALARIO["novoProfessor.Salario = salarioDigitado"]

    ASSIGN_SALARIO --> REPO_ADD["repositorioPessoas.Adicionar(novoProfessor)"]
    REPO_ADD --> SUCCESS_MSG["Exibir: Professor adicionado com sucesso!"]
    SUCCESS_MSG --> FINALLY_BLOCK

    FINALLY_BLOCK["Bloco finally: Pressione ENTER para voltar..."] --> READ_KEY[/"Console.ReadLine()"/]
    READ_KEY --> END(["Fim: Retorna controle ao MenuConsole"])

    %% Tratamento de Exceções
    PARSE_ID -.->|Erro de Formato| CATCH_EX["catch (Exception ex): Exibir mensagem de erro"]
    PARSE_IDADE -.->|Erro de Formato| CATCH_EX
    PARSE_SALARIO -.->|Erro de Formato| CATCH_EX
    CATCH_EX --> FINALLY_BLOCK
```

---

## 📝 Dicionário de Dados e Transformações

| Campo Coletado | Tipo Primitivo | Regra de Conversão | Exemplo de Entrada | Valor em Memória |
| :--- | :---: | :--- | :--- | :--- |
| **ID** | `int` | `int.Parse(entradaId)` | `"2"` | `2` |
| **Nome** | `string` | Atribuição direta | `"Carlos Alberto"` | `"Carlos Alberto"` |
| **Idade** | `int` | `int.Parse(entradaIdade)` | `"45"` | `45` |
| **Disciplina** | `string` | Atribuição direta | `"Matemática"` | `"Matemática"` |
| **Salário** | `double` | `double.Parse(entradaSalario, CultureInfo.GetCultureInfo("pt-BR"))` | `"7.822,00"` | `7822.0` |

---

## 🎯 Destaques de Engenharia
1. **Localização Monetária (`pt-BR`)**: Reconhece o ponto como separador de milhar (`7.822`) e a vírgula como separador decimal (`,00`), garantindo suporte nativo a valores da economia brasileira.
2. **Encapsulamento de Modelo**: A instância `Professor` herda os campos básicos de `Pessoa` e adiciona seus campos especializados de forma coesa.

---

[⬅️ Voltar para o Índice de Fluxos](./README.md) | [🏠 Voltar para a Documentação Central](../README.md)

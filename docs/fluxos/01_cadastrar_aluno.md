# 🔀 Fluxo de Dados: Opção 1 - Cadastrar Novo Aluno

* **Operação CRUD:** Create (Criação)
* **Componente Responsável:** `Views/Screens/CadastrarAlunoScreen.cs`
* **Entidade Manipulada:** `Models/Aluno.cs`

---

## 📊 Fluxograma de Execução e Dados

```mermaid
flowchart TD
    START(["Início: CadastrarAlunoScreen.Executar()"]) --> CLEAR["Limpar Console se não redirecionado"]
    CLEAR --> HEADER["Exibir Cabeçalho: NOVO CADASTRO DE ALUNO"]
    HEADER --> INSTANTIATE["Criar nova instância: novoAluno = new Aluno()"]
    
    INSTANTIATE --> READ_ID[/"Ler entradaId (Console.ReadLine)"/]
    READ_ID --> PARSE_ID["Converter para int: int.Parse(entradaId)"]
    PARSE_ID --> ASSIGN_ID["novoAluno.Id = idDigitado"]

    ASSIGN_ID --> CHECK_EXISTS{"repositorioPessoas.ObterPorId(novoAluno.Id) != null?"}
    
    CHECK_EXISTS -->|"Sim (ID Duplicado)"| WARN_DUPLICATE["Exibir: Já existe pessoa com este ID!"]
    WARN_DUPLICATE --> FINALLY_BLOCK

    CHECK_EXISTS -->|"Não (ID Disponível)"| READ_NOME[/"Ler entradaNome (Console.ReadLine)"/]
    READ_NOME --> ASSIGN_NOME["novoAluno.Nome = nomeDigitado"]

    ASSIGN_NOME --> READ_IDADE[/"Ler entradaIdade (Console.ReadLine)"/]
    READ_IDADE --> PARSE_IDADE["Converter para int: int.Parse(entradaIdade)"]
    PARSE_IDADE --> ASSIGN_IDADE["novoAluno.Idade = idadeDigitada"]

    ASSIGN_IDADE --> PROMPT_NOTA[/"Exibir: Digite a Nota (Ex: 4.7 ou 9.5): "/]
    PROMPT_NOTA --> READ_NOTA[/"Ler entradaNota (Console.ReadLine)"/]
    READ_NOTA --> PARSE_NOTA["Converter via CultureInfo.InvariantCulture: double.Parse(entradaNota, ...)"]
    PARSE_NOTA --> ASSIGN_NOTA["novoAluno.Nota = notaDigitada"]

    ASSIGN_NOTA --> REPO_ADD["repositorioPessoas.Adicionar(novoAluno)"]
    REPO_ADD --> SUCCESS_MSG["Exibir: Aluno adicionado com sucesso!"]
    SUCCESS_MSG --> FINALLY_BLOCK

    FINALLY_BLOCK["Bloco finally: Pressione ENTER para voltar..."] --> READ_KEY[/"Console.ReadLine()"/]
    READ_KEY --> END(["Fim: Retorna controle ao MenuConsole"])

    %% Tratamento de Exceções
    PARSE_ID -.->|Erro de Formato| CATCH_EX["catch (Exception ex): Exibir mensagem de erro"]
    PARSE_IDADE -.->|Erro de Formato| CATCH_EX
    PARSE_NOTA -.->|Erro de Formato| CATCH_EX
    CATCH_EX --> FINALLY_BLOCK
```

---

## 📝 Dicionário de Dados e Transformações

| Campo Coletado | Tipo Primitivo | Regra de Conversão | Exemplo de Entrada | Valor em Memória |
| :--- | :---: | :--- | :--- | :--- |
| **ID** | `int` | `int.Parse(entradaId)` | `"1"` | `1` |
| **Nome** | `string` | Atribuição direta | `"Lucas Silva"` | `"Lucas Silva"` |
| **Idade** | `int` | `int.Parse(entradaIdade)` | `"20"` | `20` |
| **Nota** | `double` | `double.Parse(entradaNota, CultureInfo.InvariantCulture)` | `"9.5"` | `9.5` |

---

## 🎯 Destaques de Engenharia
1. **Validação Fail-Fast**: O sistema valida se o ID já existe antes de pedir o restante das informações, poupando o tempo do usuário.
2. **Ponto Flutuante Invariante**: O uso de `CultureInfo.InvariantCulture` impede que `"9.5"` seja interpretado como `95` em sistemas operacionais configurados em português brasileiro.

---

[⬅️ Voltar para o Índice de Fluxos](./README.md) | [🏠 Voltar para a Documentação Central](../README.md)

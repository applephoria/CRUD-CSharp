# 🔀 Fluxo de Dados: Opção 4 - Excluir Pessoa por ID

* **Operação CRUD:** Delete (Exclusão)
* **Componente Responsável:** `Views/Screens/ExcluirPessoaScreen.cs`
* **Entidade Manipulada:** `Models/Pessoa.cs` (Coleção no Repositório)

---

## 📊 Fluxograma de Execução e Exclusão

```mermaid
flowchart TD
    START(["Início: ExcluirPessoaScreen.Executar()"]) --> CLEAR["Limpar Console se não redirecionado"]
    CLEAR --> HEADER["Exibir Cabeçalho: EXCLUIR PESSOA POR ID"]

    HEADER --> PROMPT_ID[/"Exibir: Digite o ID da pessoa que deseja excluir: "/]
    PROMPT_ID --> READ_ID[/"Ler entradaId (Console.ReadLine)"/]
    READ_ID --> PARSE_ID["Converter para int: int.Parse(entradaId)"]

    PARSE_ID --> QUERY_REPO["Consultar: pessoaEncontrada = repositorioPessoas.ObterPorId(idParaExcluir)"]

    QUERY_REPO --> CHECK_NULL{"pessoaEncontrada == null?"}

    CHECK_NULL -->|"Sim (Não Encontrada)"| NOT_FOUND["Exibir: Nenhuma pessoa encontrada com esse ID!"]
    NOT_FOUND --> FINALLY_BLOCK

    CHECK_NULL -->|"Não (Pessoa Localizada)"| REPO_DELETE["Executar: repositorioPessoas.Excluir(idParaExcluir)"]
    REPO_DELETE --> SUCCESS_MSG["Exibir: Pessoa com ID idParaExcluir excluida com sucesso!"]
    SUCCESS_MSG --> FINALLY_BLOCK

    FINALLY_BLOCK["Bloco finally: Pressione ENTER para voltar..."] --> READ_KEY[/"Console.ReadLine()"/]
    READ_KEY --> END(["Fim: Retorna ao MenuConsole"])

    %% Tratamento de Exceções
    PARSE_ID -.->|Entrada Não Numérica| CATCH_EX["catch (Exception ex): Exibir erro de exclusão"]
    CATCH_EX --> FINALLY_BLOCK
```

---

## 📋 Cenários de Execução e Resposta

| Cenário | Entrada do Usuário | Estado do Repositório | Resposta do Sistema | Ação no Repositório |
| :--- | :---: | :--- | :--- | :---: |
| **Exclusão com Sucesso** | `"1"` | ID 1 existe na lista | `"Pessoa com ID 1 excluida com sucesso!"` | Remove item da `List<Pessoa>` |
| **ID Inexistente** | `"99"` | ID 99 não cadastrado | `"Nenhuma pessoa encontrada com esse ID!"` | Nenhuma alteração |
| **Entrada Inválida** | `"abc"` | Qualquer | `"Erro ao excluir pessoa: A cadeia de caracteres de entrada não estava em um formato correto."` | Capturado pelo `catch` |

---

## 🎯 Destaques de Engenharia
1. **Verificação Prévia de Existência**: Evita invocar operações destrutivas sem confirmar se a entidade de fato existe no repositório.
2. **Isolamento de Memória**: O método `repositorioPessoas.Excluir(id)` encapsula a remoção da lista interna usando `_listaPessoas.Remove(pessoa)`.

---

[⬅️ Voltar para o Índice de Fluxos](./README.md) | [🏠 Voltar para a Documentação Central](../README.md)

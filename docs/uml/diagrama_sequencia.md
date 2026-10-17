# ⏱️ Diagramas de Sequência (Sequence Diagrams)

* **Categoria UML:** Diagrama de Interação
* **Propósito:** Demonstrar a troca de mensagens ordenada no tempo entre os diferentes componentes de software durante a execução das tarefas principais.

---

## 1. Diagrama de Sequência: Inicialização e Injeção de Dependências

Mapeia a criação das instâncias e a ligação desacoplada dos componentes antes da exibição do menu ao usuário.

```mermaid
sequenceDiagram
    autonumber
    actor Dev as Sistema Operacional
    participant P as Program (Main)
    participant S as Startup
    participant R as PessoaRepository
    participant M as MenuConsole

    Dev->>P: Ponto de Entrada: Main()
    P->>S: Startup.Inicializar()
    activate S
    S->>R: new PessoaRepository()
    activate R
    R-->>S: Instância concreta de repositório
    deactivate R
    S->>M: new MenuConsole(repositorioPessoas)
    activate M
    M-->>S: Menu configurado com DIP
    deactivate M
    S-->>P: Instância de MenuConsole
    deactivate S
    P->>M: menu.ExibirMenu()
    activate M
    Note over M: Inicia o loop de interação com o usuário
```

---

## 2. Diagrama de Sequência: Cadastro de Aluno (Validação Fail-Fast)

Demonstra a leitura dos dados do console, a verificação de duplicidade de ID no repositório e a persistência final.

```mermaid
sequenceDiagram
    autonumber
    actor User as Operador do Sistema
    participant M as MenuConsole
    participant Screen as CadastrarAlunoScreen
    participant Repo as IPessoaRepository
    participant Entity as novoAluno : Aluno

    User->>M: Digita "1" (Cadastrar Aluno)
    M->>Screen: CadastrarAlunoScreen.Executar(repositorioPessoas)
    activate Screen
    Screen->>Entity: new Aluno()

    User->>Screen: Digita ID (ex: 1)
    Screen->>Repo: ObterPorId(1)
    activate Repo
    Repo-->>Screen: Retorna null (ID Livre)
    deactivate Repo

    User->>Screen: Digita Nome (ex: "Lucas")
    User->>Screen: Digita Idade (ex: "20")
    User->>Screen: Digita Nota (ex: "9.5")
    Note over Screen: Converte com CultureInfo.InvariantCulture

    Screen->>Repo: Adicionar(novoAluno)
    activate Repo
    Repo-->>Screen: Aluno persistido na List<Pessoa>
    deactivate Repo

    Screen-->>User: Exibe "Aluno adicionado com sucesso!"
    User->>Screen: Pressiona ENTER
    Screen-->>M: Retorna o controle para o menu
    deactivate Screen
```

---

## 3. Diagrama de Sequência: Listagem e Apresentação Polimórfica

Demonstra como o repositório entrega a lista genérica de `Pessoa` e o loop executa dinamicamente o método sobrescrito de cada tipo derivado.

```mermaid
sequenceDiagram
    autonumber
    actor User as Operador do Sistema
    participant M as MenuConsole
    participant Screen as ListarPessoasScreen
    participant Repo as IPessoaRepository
    participant Pessoa as pessoa : Pessoa

    User->>M: Digita "3" (Listar Pessoas)
    M->>Screen: ListarPessoasScreen.Executar(repositorioPessoas)
    activate Screen
    Screen->>Repo: ObterTodos()
    activate Repo
    Repo-->>Screen: Retorna List<Pessoa>
    deactivate Repo

    loop Para cada Pessoa na lista
        Screen->>Pessoa: pessoa.Apresentar()
        activate Pessoa
        alt Se a instância for Aluno
            Note over Pessoa: Formata Nota com ponto ("0.0")
            Pessoa-->>Screen: ALUNO: ... | Nota: 9.5
        else Se a instância for Professor
            Note over Pessoa: Formata Salário com pt-BR ("N2")
            Pessoa-->>Screen: PROFESSOR: ... | Salario: R$ 7.822,00
        end
        deactivate Pessoa
    end

    Screen-->>User: Exibe Total de Pessoas cadastradas
    User->>Screen: Pressiona ENTER
    Screen-->>M: Retorna ao Menu Principal
    deactivate Screen
```

---

[⬅️ Voltar para o Índice de UML](./README.md) | [🏠 Voltar para a Documentação Central](../README.md)

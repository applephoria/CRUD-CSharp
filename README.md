# 🎓 Sistema Escolar CRUD em C# (.NET) <img src="https://media.giphy.com/media/WUlplcMpOCEmTGBtBW/giphy.gif" width="30">

<p align="left">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" />
  <img src="https://img.shields.io/badge/.NET_Framework_4.8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual-studio&logoColor=white" />
  <img src="https://img.shields.io/badge/Clean_Architecture-black?style=for-the-badge&logo=blueprint&logoColor=white" />
  <img src="https://img.shields.io/badge/Status-Concluído-success?style=for-the-badge" />
</p>

---

## 📌 Sobre o Projeto & Minha Jornada de Aprendizado

> 👋 Olá! Este é o meu **primeiro projeto desenvolvido em C# e .NET**. 
>
> Estou no processo contínuo de aprofundar meus estudos em **Engenharia de Software**, **Programação Orientada a Objetos (POO)** e **Arquitetura de Sistemas**. Desenvolvi esta aplicação em console para ir muito além de um CRUD básico, aplicando padrões de projeto reais utilizados pelo mercado e entendendo a fundo como os dados navegam entre as camadas e na memória RAM.

---

## 🧠 O Que Aprendi e Apliquei Neste Projeto

Durante a concepção e implementação deste sistema, pude praticar conceitos de nível acadêmico e corporativo:

1. **Programação Orientada a Objetos Avançada (POO):**
   * **Abstração e Herança:** Criação da classe abstrata `Pessoa` servindo de molde base para as entidades derivadas `Aluno` e `Professor`.
   * **Polimorfismo Real:** Sobrescrita do método abstrato `Apresentar()` em cada subclasse, permitindo que cada tipo se apresente com sua formatação exclusiva sem necessidade de condicionais na tela.
   * **Pattern Matching Moderno:** Uso de `if (pessoa is Aluno aluno)` e `else if (pessoa is Professor professor)` para inspeção segura de tipos sem necessidade de coerções (*typecasts*) manuais.

2. **Arquitetura Desacoplada e Princípios SOLID:**
   * **Repository Pattern:** Separação estrita entre o acesso aos dados e a interface visual através da interface `IPessoaRepository`.
   * **S - Princípio da Responsabilidade Única (SRP):** Cada tela do sistema (`CadastrarAlunoScreen`, `ListarPessoasScreen`, etc.) vive em sua própria classe especialista.
   * **D - Princípio da Inversão de Dependência (DIP):** O menu principal recebe a interface `IPessoaRepository` via injeção por construtor, dependendo de abstrações e não de implementações concretas.

3. **Programação Defensiva e Resiliência:**
   * **Zero Exception Crashes:** Uso de `int.TryParse` com parâmetros `out` para garantir validações sem provocar quebras por exceções desnecessárias.
   * **Validação Antecipada (*Fail-Fast*):** Verificação imediata de duplicidade de ID antes de solicitar os demais dados ao usuário.
   * **Localização Cultural Precisa:** Formatação de notas de alunos com ponto (`CultureInfo.InvariantCulture`) e salários com separador de milhar e vírgula (`CultureInfo.GetCultureInfo("pt-BR")`).

---

## 📑 Hub de Documentação Técnica e Diagramas

Este repositório possui uma documentação técnica completa para consulta dos diagramas arquiteturais e fluxos de processos:

| Seção de Documentação | Conteúdo Detalhado | Link de Acesso |
| :--- | :--- | :---: |
| **Central de Documentação** | Visão geral da arquitetura em 3 camadas e decisões de engenharia. | [📂 Acessar Hub Docs](./docs/README.md) |
| **Modelagem UML Completa** | Diagramas de Classes, Casos de Uso e Sequência de Interação. | [📐 Ver Diagramas UML](./docs/uml/README.md) |
| **Fluxos de Dados por Opção** | Mapeamento detalhado de cada uma das 6 opções do console com fluxogramas. | [🔀 Ver Fluxos de Dados](./docs/fluxos/README.md) |

---

## 🏛️ Diagrama Estrutural de Classes (UML)

```mermaid
classDiagram
    direction TD

    class Pessoa {
        <<abstract>>
        +int Id
        +string Nome
        +int Idade
        +Apresentar()* void
    }

    class Aluno {
        +double Nota
        +Apresentar() void
    }

    class Professor {
        +string Disciplina
        +double Salario
        +Apresentar() void
    }

    class IPessoaRepository {
        <<interface>>
        +Adicionar(Pessoa pessoa) void
        +ObterTodos() List~Pessoa~
        +ObterPorId(int id) Pessoa
        +Excluir(int id) void
        +Atualizar(Pessoa pessoa) void
    }

    class PessoaRepository {
        -List~Pessoa~ _listaPessoas
        +Adicionar(Pessoa pessoa) void
        +ObterTodos() List~Pessoa~
        +ObterPorId(int id) Pessoa
        +Excluir(int id) void
        +Atualizar(Pessoa pessoa) void
    }

    class MenuConsole {
        -IPessoaRepository _repositorioPessoas
        +MenuConsole(IPessoaRepository repositorioPessoas)
        +ExibirMenu() void
    }

    class Startup {
        +Inicializar()$ MenuConsole
    }

    Pessoa <|-- Aluno : Herda
    Pessoa <|-- Professor : Herda
    IPessoaRepository <|.. PessoaRepository : Implementa
    PessoaRepository o-- Pessoa : Armazena
    MenuConsole --> IPessoaRepository : Depende
    Startup ..> PessoaRepository : Instancia
    Startup ..> MenuConsole : Injeta
    Startup ..> IPessoaRepository : Utiliza
```

---

## 📁 Estrutura de Diretórios do Projeto

```text
CRUD/
├── docs/                           # Documentação Técnica e Diagramas
│    ├── README.md                  # Hub Central de Documentação
│    ├── uml/                       # Diagramas UML (Classes, Casos de Uso, Sequência)
│    └── fluxos/                    # Fluxogramas detalhados das Opções 1 a 5 e 0
│
├── Models/                         # Camada de Domínio / Entidades
│    ├── Pessoa.cs                  # Classe Abstrata base
│    ├── Aluno.cs                   # Entidade Aluno (herda de Pessoa)
│    └── Professor.cs               # Entidade Professor (herda de Pessoa)
│
├── Repositories/                   # Camada de Acesso a Dados
│    ├── IPessoaRepository.cs       # Interface de Contrato CRUD
│    └── PessoaRepository.cs        # Implementação em memória (List<Pessoa>)
│
├── Views/                          # Camada de Apresentação / Interface
│    ├── MenuConsole.cs             # Orquestrador do Menu Principal
│    └── Screens/                   # Telas Especialistas (SRP)
│         ├── CadastrarAlunoScreen.cs
│         ├── CadastrarProfessorScreen.cs
│         ├── ListarPessoasScreen.cs
│         ├── ExcluirPessoaScreen.cs
│         └── AtualizarPessoaScreen.cs
│
├── Program.cs                      # Ponto de entrada (Main)
├── Startup.cs                      # Configuração e Injeção de Dependências
└── README.md                       # Documentação principal
```

---

## ⚙️ Como Executar a Aplicação Localmente

### Pré-requisitos
* [.NET SDK](https://dotnet.microsoft.com/download) instalado (ou Visual Studio 2022 com suporte a .NET Framework 4.8 / .NET).

### Passo a Passo
1. Clone o repositório:
   ```bash
   git clone https://github.com/applephoria/CRUD-CSharp.git
   ```
2. Acesse a pasta do projeto:
   ```bash
   cd CRUD-CSharp
   ```
3. Compile a solução:
   ```bash
   dotnet build
   ```
4. Execute o programa:
   ```bash
   dotnet run
   ```

---

# <img src="https://media1.giphy.com/media/JZ40cnfnN11KycrvMF/giphy.gif?cid=ecf05e47a0n3gi1bfqntqmob8g9aid1oyj2wr3ds3mg700bl&rid=giphy.gif" width="20" /> Used languages and tools:

<p align="left">
  <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" width="50" height="50" alt="C#" />
  <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original.svg" width="50" height="50" alt=".NET" />
  <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/visualstudio/visualstudio-plain.svg" width="50" height="50" alt="Visual Studio" />
  <img src="https://www.vectorlogo.zone/logos/visualstudio_code/visualstudio_code-icon.svg" width="50" height="50" alt="VS Code" />
  <img src="https://www.vectorlogo.zone/logos/git-scm/git-scm-icon.svg" width="50" height="50" alt="Git" />
  <img src="https://www.vectorlogo.zone/logos/github/github-icon.svg" width="50" height="50" alt="GitHub" />
</p>

---

# 🙋‍♂️ Connect with me 

<table>
  <tr>
    <a target="_blank" href="https://beacons.ai/applephoria/aboutme"><img src="https://img.shields.io/badge/-WEB-FF4088?style=for-the-badge&logo=Hugo&logoColor=white" /></a>
    <a href="https://www.linkedin.com/in/marcelflorentino/"><img src="https://img.shields.io/badge/linkedin-0077B5.svg?style=for-the-badge&logo=linkedin&logoColor=white" /></a>
    <a href="https://www.instagram.com/applephoria/" target="_blank"><img src="https://img.shields.io/badge/-Instagram-%23E4405F?style=for-the-badge&logo=instagram&logoColor=white" /></a>
    <a href="mailto:eumarcelflorentino@gmail.com"><img src="https://img.shields.io/badge/-Gmail-%23333?style=for-the-badge&logo=gmail&logoColor=white" /></a>
  </tr> 
</table>

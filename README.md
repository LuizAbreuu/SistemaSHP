<<<<<<< HEAD
# 💻 Sistema de Controle SHP - Computadores e Notebooks

Um sistema construído em arquitetura web corporativa para realizar o gerenciamento de inventário ágil de **Notebooks e Desktops** alocados aos usuários, integrando segurança local e permitindo fáceis exportações analíticas ou auditorias (via relatórios Excel). 

Atuando sob um padrão sólido e separação rigorosa de instâncias, o projeto garante forte controle a administradores e manutenções simplificadas.

---

## 🛠️ Tecnologias e Tecnologias-Chave

O sistema acompanha as atualizações de estabilidade recomendadas pela Microsoft utilizando majoritariamente a plataforma do **.NET 8**:

- **Framework Web**: `ASP.NET Core 8.0` (Arquitetura Padrão MVC)
- **Linguagem Principal**: `C#` (C-Sharp)
- **Persistência de Dados**: `Entity Framework Core 8.x` (Abordagem Code-First)
- **Banco de Dados**: `Microsoft SQL Server`
- **Autenticação**: Nativa/Embutida usando *Cookies* (`Microsoft.AspNetCore.Authentication.Cookies`), protegendo as rotas da aplicação via `[Authorize]`.
- **Relatórios**: Biblioteca `ClosedXML` permitindo que a exibição em tela seja baixada para relatórios consolidados em Excel `.xlsx`.
- **Injeção de Dependência da Camada**: Nativa do framework mantendo escopos limpos (`AddScoped`, `AddSingleton`, etc).
- **Criptografia Padrão**: Hash + Salt gerados via arrays de Bytes isolados impedindo que senhas de contas flutuem claras dentro do Banco.

---

## 🧩 Arquitetura e Boas Práticas Implementadas

O projeto obedece extensivamente aos princípios **SOLID**, focando estritamente em *Inversão de Dependências (D)* e *Responsabilidade Única (S)* que criaram as camadas do software:

1. **Camada de Apresentação (Controllers & Views)**
   Responsável somente por interceptar HTTP *(GET/POST)*, acionar quem processará a informação e repassar para a tela (*Razor `cshtml`*). Os Controllers são enxutos e seguros.
   
2. **Camada de Transferência (ViewModels e DTOs)**
   Para evitar vazamentos de estrutura técnica de persistência para as telas do usuário final (over-posting / under-posting), adotamos a separação usando objetos como o `NotebookDesktopViewModel`. Neles residem unicamente as diretivas limitadoras das View (`[Required]`, etc).
   
3. **Camada de Serviço Core (Services & Interfaces)**
   Toda regra de negócios, hashings ou processamento pesado acontece isoladamente aqui (Ex: `NotebookDesktopService` e `SenhaService`), sendo que o Controlador interage apenas com a "promessa" dessa camada (suas respectivas `Interfaces`).
   
4. **Camada de Persistência (Data / EF Core DbContext)**
   Condução limpa e direta do Modelo Entity Framework e sua gerência de dados (`Models/Notebook_DesktopModel`).

---

## ⚙️ Pré-Requisitos

Antes de iniciar você precisará das seguintes ferramentas:

1. [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
2. Carga instalada do **SQL Server** (seja _Express_, _Developer_, ou o _LocalDB_ atrelado pelo Visual Studio).
3. Ferramentas do Entity Framework Global CLI (Pode ser instalado via `dotnet tool install --global dotnet-ef`).

---

## 🚀 Como Iniciar e Rodar a Aplicação

Siga o passo-a-passo local para testar essa plataforma e acopla-la ao seu SQL local.

1. **Clonar ou posicionar a Solução:**
   Abra os arquivos em um ambiente de desenvolvimento limpo utilizando sua IDE preferida. O projeto foi primariamente testado na plataforma Microsoft Visual Studio.
   
2. **Setup do AppSettings (User Secrets ou AppSettings.json)**
   Verifique no seu `appsettings.json`, no interior do diretório primário, sua string de conexão:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "server=NOME_DO_SEU_SERVIDOR_AQUI; Database=Notebook_Desktops; Integrated Security=True;Encrypt=True;TrustServerCertificate=True"
   }
   ```
   > 💡 *Nota*: É extremamente recomendado que em produção as senhas das ConnectionStrings sejam escondidas preferencialmente em variáveis da SO ou recursos do gerenciador de Cloud.

3. **Gerar a Estrutura do Banco SQL**:
   Navegue no console ou PowerShell até a raiz interna do projeto (`cd SHP - Sociedade Hípica Paulista`). Atualize/Gere tabelas rodando:
   ```bash
   dotnet ef database update
   ```

4. **Rodar Aplicação**:
   Pode ser perfeitamente executada e acessada apertando F5 em seu visual studio ou no terminal rodando localmente a rede via web:
   ```bash
   dotnet run
   ```
=======
SHP - SOCIEDADE HÍPICA PAULISTA 

Este sistema está sendo criado com o intuito de substituirmos uma planilha em excel, onde temos uma base de dados sobre nossos equipamentos dentro da empresa, a ideia é que com esse sistema, não será preciso se preocupar em salvar ou não a planilha pois tudo é salvo dentro de um banco de dados (SQL Server).  


## Rodando localmente

Clone o projeto

```bash
  git clone git@github.com:LuizAbreuu/SistemaSHP.git
```

Configurações para rodar a aplicação;
Configurar as informações do banco de dados no appsettings.json, colocando o nome da Database e as informações do seu banco de dados SQL “DefaultConnection”.

no Visual Studio precisa ir na aba tools e abrir o Package Manager Console, colocando o comando Update-Database -Context BancoDBContext Que o banco de dados vai ser criado no SQL.

Para logar no sistema tem que criar um usuario, mas para isso basta rodar o projeto e fazer um cadastro no botão cadastre-se( por enquanto sem muitas regras de criação de cadastro)

## Stack utilizada

**Front-end:** ASP.NET MVC

**Back-end:** ASP.NET MVC

>>>>>>> 3f08b921be822f9ec7f141a38a851a646ebf4833

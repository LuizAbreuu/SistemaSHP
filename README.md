# 💻 Sistema SHP - Gestão de Equipamentos 

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)](#)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-blue?logo=dotnet)](#)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-3dbbcf?logo=nuget)](#)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?logo=microsoftsqlserver&logoColor=white)](#)

O **Sistema SHP** (Sociedade Hípica Paulista) é uma plataforma web desenvolvida para substituir controles manuais (como planilhas Excel) no gerenciamento de inventário de equipamentos de TI, especificamente notebooks e desktops. 

O sistema oferece uma solução robusta, segura e centralizada, garantindo a persistência dos dados em um banco de dados relacional (SQL Server) e facilitando a gestão, rastreabilidade e exportação de dados.

---

## ✨ Funcionalidades

- **Autenticação e Segurança:** Sistema de login com criptografia de senhas (Hash/Salt) e controle de sessão seguro via Cookies.
- **Gestão de Equipamentos:** Cadastro, edição, exclusão e visualização (CRUD) detalhada de notebooks e desktops.
- **Auditoria e Relatórios:** Exportação dos dados de equipamentos diretamente para relatórios consolidados em Excel `.xlsx` (utilizando a biblioteca ClosedXML).
- **Interface Responsiva:** Design amigável e adaptável, com tabelas interativas e suporte a dispositivos variados.
- **Prevenção de Perda de Dados:** Substituição de planilhas voláteis por um banco de dados estruturado e persistente.

---

## 🏗️ Arquitetura do Projeto (Clean Architecture)

O projeto foi construído utilizando os princípios de **Clean Architecture (Arquitetura Limpa)** e **SOLID**, garantindo baixo acoplamento, alta coesão e facilidade de manutenção. A solução está dividida nas seguintes camadas:

1. **`SistemaSHP.Domain` (Camada de Domínio)**
   - Coração da aplicação. Contém as entidades de negócio (ex: `Notebook_DesktopModel`, `Usuario`) e as interfaces dos repositórios. Não depende de nenhuma outra camada.

2. **`SistemaSHP.Application` (Camada de Aplicação)**
   - Contém a lógica de negócio e os casos de uso (Services: `LoginService`, `NotebookDesktopService`, `SenhaService`). Faz a ponte entre a apresentação e o domínio.

3. **`SistemaSHP.Infrastructure` (Camada de Infraestrutura)**
   - Responsável pela comunicação com agentes externos (Banco de Dados). Contém o contexto do Entity Framework (`ApplicationDbContext`) e a implementação dos repositórios de dados.

4. **`SHP - Sociedade Hípica Paulista` (Camada de Apresentação / UI)**
   - O projeto Web em **ASP.NET Core MVC**. Responsável apenas por interceptar requisições HTTP, delegar o processamento para a camada de Aplicação e retornar as Views (telas Razor) ao usuário.

---

## 🛠️ Tecnologias e Ferramentas

- **Backend:** C#, .NET 8.0, ASP.NET Core MVC
- **Banco de Dados:** Microsoft SQL Server
- **ORM:** Entity Framework Core 8 (Code-First)
- **Segurança:** Autenticação por Cookies (`Microsoft.AspNetCore.Authentication.Cookies`)
- **Utilitários:** `ClosedXML` (para geração de arquivos Excel)
- **Frontend:** Razor Pages (HTML, CSS, JavaScript), Bootstrap (para responsividade)

---

## 📁 Estrutura de Diretórios

```plaintext
SistemaSHP/
│
├── SistemaSHP.Domain/              # Entidades, Interfaces de Repositório
├── SistemaSHP.Application/         # Regras de Negócio (Services), DTOs, ViewModels
├── SistemaSHP.Infrastructure/      # DbContext, Repositórios, Migrations
└── SHP - Sociedade Hípica Paulista/ # Projeto Web MVC (Controllers, Views, wwwroot)
```

---

## ⚙️ Pré-Requisitos

Antes de iniciar, você precisará ter instalado em sua máquina:

1. [SDK do .NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
2. [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) (Express, Developer ou LocalDB)
3. Uma IDE de sua preferência ([Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/) recomendado, ou VS Code).
4. Ferramenta CLI do Entity Framework (Instale via: `dotnet tool install --global dotnet-ef`)

---

## 🚀 Como Executar o Projeto Localmente

1. **Clone o repositório:**
   ```bash
   git clone git@github.com:LuizAbreuu/SistemaSHP.git
   cd SistemaSHP/SistemaSHP
   ```

2. **Configuração do Banco de Dados (`appsettings.json`):**
   No projeto de Apresentação (`SHP - Sociedade Hípica Paulista`), localize ou crie o arquivo `appsettings.json` e configure a string de conexão `DefaultConnection` para o seu servidor SQL:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=SEU_SERVIDOR; Database=BancoDBContext; Integrated Security=True; Encrypt=True; TrustServerCertificate=True"
   }
   ```

3. **Criação do Banco de Dados (Migrations):**
   Abra o **Package Manager Console** (Visual Studio) ou o terminal na pasta do projeto principal e rode o comando para gerar o banco:
   
   - *Via Package Manager Console:*
     ```powershell
     Update-Database
     ```
   - *Via .NET CLI:*
     ```bash
     dotnet ef database update --project SistemaSHP.Infrastructure --startup-project "SHP - Sociedade Hípica Paulista"
     ```

4. **Executando a Aplicação:**
   Aperte `F5` no Visual Studio ou execute via terminal na pasta web:
   ```bash
   dotnet run --project "SHP - Sociedade Hípica Paulista"
   ```

5. **Primeiro Acesso:**
   A aplicação será iniciada na página de Login. Para acessar, clique em **Cadastre-se**, crie um usuário teste e depois faça o login no sistema.

---

## 🤝 Sobre o Projeto

Desenvolvido para atender às necessidades de inventário da **Sociedade Hípica Paulista**, garantindo confiabilidade, segurança e agilidade no controle dos equipamentos da empresa.

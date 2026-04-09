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


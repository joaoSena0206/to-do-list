# To-do List API

Uma Web Api feita com ASP.NET Core e SQL Server, feita com o intuito de gerenciar tarefas do usuário.

## Índice

* [Tecnologias Utilizadas](#tecnologias-utilizadas)
* [Estrutura do Projeto](#estrutura-do-projeto)
* [Endpoints da API](#endpoints-da-api)
* [Instalação](#instalacao)
* [Licença[(#licenca)

## Tecnologias Utilizadas

- ASP.NET Core (.NET 9.0)
- SQL Server (20.2)

## Estrutura do Projeto

Projeto feito utilizando uma arquitetura em camadas com:
- Controllers (Controle das requisições)
- DTOs (Transferência de dados entre o cliente e o servidor)
- Services (Gestão da lógica de negócios)
- Models (Passagem de dados para a camada DAL)
- DALs (Interação com o banco)

## Endpoints da API

### Auth

| Método | Endpoint          | Descrição                            | Autenticação |
|--------|-------------------|--------------------------------------|--------------|
| POST   | `api/auth/signup` | Cria um novo usuário                 | ❌           |
| POST   | `api/auth/signin` | Loga com o usuário, retornando o JWT | ❌           |

### Task

| Método | Endpoint   | Descrição                                 | Autenticação |
|--------|------------|-------------------------------------------|--------------|
| POST   | `api/task` | Cria uma nova tarefa                      | ✅           |           
| GET    | `api/task` | Pega todas as tarefas do usuário          | ✅           |
| PATCH  | `api/task` | Atualiza o status da tarefa para completo | ✅           |
| DELETE | `api/task` | Deleta a tarefa                           | ✅           |

## Instalação

### Pré-requisitos

- ASP.NET Core (NET 9.0)
- SQL Server (20.2)

### Passo a Passo

1. Baixe o projeto na sua máquina:
	```bash
	git clone https://github.com/joaoSena0206/to-do-list.git
	```
2. Entre na pasta do projeto e depois na do banco:
	```bash
	cd to-do-list
	cd banco
	```
3. Execute o script do banco pelo SGBD do SQl Server ou pelo comando abaixo no terminal:
	```bash
	sqlcmd -S localhost -U sa -P MinhaSenha123 -d MinhaBaseDeDados -i criacao.sql
	```
4. Volte uma pasta e entre na pasta do projeto ASP.NET Core:
	```bash
	cd ..
	cd To-do-list
	```
5. Abra o arquivo appsettings.json e modifique a linha DefaultConnection com os seus dados para acessar o banco do SQL Server:
	```json
	"ConnectionStrings": {
		"DefaultConnection": "Server=localhost; Database=MinhaBaseDeDados; User Id=sa; Password=MinhaSenha123; TrustServerCertificate=True;"
	},
	```
6. Caso queria também pode modificar os dados do JWT:
	```json
	"JWTSettings": {
		"SecretKey": "mgfSXjO6rPqot7Lf3hNvOXIfF2ddsHkI",
		"Issuer": "https://localhost:7238",
		"Audience": "https://localhost:7238"
	}
	```
7. Quando quiser rodar o projeto só rodar esse comando na pasta:
	```bash
	dotnet run
	```
	
## Licença

Este projeto está licenciado sob a Licença MIT.
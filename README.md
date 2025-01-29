# To-do List API

Uma Web Api feita com ASP.NET Core e SQL Server, feita com o intuito de gerenciar tarefas do usuário.

## Índice

* [Tecnologias Utilizadas](#tecnologias-utilizadas)
* [Estrutura do Projeto](#estrutura-do-projeto)
* [Endpoints da API](#endpoints-da-api)

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

USE [todo-list];

DROP TABLE IF EXISTS usuario;
DROP TABLE IF EXISTS tarefa;

CREATE TABLE usuario 
(
	nm_email_usuario NVARCHAR(254) PRIMARY KEY,
	nm_senha NVARCHAR(255) NOT NULL
);

CREATE TABLE tarefa
(
	cd_tarefa INT PRIMARY KEY IDENTITY(1, 1),
	nm_email_usuario NVARCHAR(254) NOT NULL,
	nm_titulo_tarefa NVARCHAR(255) NOT NULL,
	ds_tarefa NVARCHAR(MAX),
	dt_vencimento_tarefa DATETIME,
	ic_concluido_tarefa BIT,

	CONSTRAINT fk_tarefa_usuario FOREIGN KEY (nm_email_usuario) REFERENCES usuario(nm_email_usuario)
);
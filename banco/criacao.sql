USE [todo-list];

DROP TABLE IF EXISTS usuario;
DROP TABLE IF EXISTS tarefa;

DROP PROCEDURE IF EXISTS RegisterUser;

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
GO

CREATE PROCEDURE RegisterUser
	@Email NVARCHAR(254),
	@Password NVARCHAR(254)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM usuario WHERE nm_email_usuario = @Email)
	BEGIN
		INSERT INTO usuario VALUES
		(
			@Email,
			@Password
		);
	END
	ELSE
	BEGIN
		;THROW 50000, 'Usuário já registrado!', 1;
	END
END;
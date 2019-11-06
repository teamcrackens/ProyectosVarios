CREATE TABLE [dbo].[usuario] (
    [idusuario]      INT           IDENTITY (1, 1) NOT NULL,
    [idrol]          INT           NOT NULL,
    [nombre]         VARCHAR (100) NOT NULL,
    [tipo_documento] VARCHAR (20)  NULL,
    [num_documento]  VARCHAR (20)  NULL,
    [direccion]      VARCHAR (70)  NULL,
    [telefono]       VARCHAR (20)  NULL,
    [email]          VARCHAR (50)  NOT NULL,
    [password_hash]  VARBINARY (MAX) NOT NULL,
    [password_salt]  VARBINARY (MAX) NOT NULL,
    [condicion]      BIT           DEFAULT ((1)) NULL,
    PRIMARY KEY CLUSTERED ([idusuario] ASC),
    FOREIGN KEY ([idrol]) REFERENCES [dbo].[rol] ([idrol])
);


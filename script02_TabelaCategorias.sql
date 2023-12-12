BEGIN TRANSACTION;
GO

CREATE TABLE [TB_CATEGORIAS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TB_CATEGORIAS] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_CATEGORIAS]'))
    SET IDENTITY_INSERT [TB_CATEGORIAS] ON;
INSERT INTO [TB_CATEGORIAS] ([Id], [Nome])
VALUES (1, N'Salario'),
(2, N'Aluguel');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_CATEGORIAS]'))
    SET IDENTITY_INSERT [TB_CATEGORIAS] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231212065004_MigracaoCategoria', N'7.0.11');
GO

COMMIT;
GO


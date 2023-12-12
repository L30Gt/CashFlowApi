IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_LANCAMENTOS] (
    [Id] int NOT NULL IDENTITY,
    [TipoLancamento] int NOT NULL,
    [Descricao] nvarchar(max) NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [DataLancamento] datetime2 NOT NULL,
    CONSTRAINT [PK_TB_LANCAMENTOS] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataLancamento', N'Descricao', N'TipoLancamento', N'Valor') AND [object_id] = OBJECT_ID(N'[TB_LANCAMENTOS]'))
    SET IDENTITY_INSERT [TB_LANCAMENTOS] ON;
INSERT INTO [TB_LANCAMENTOS] ([Id], [DataLancamento], [Descricao], [TipoLancamento], [Valor])
VALUES (1, '2023-11-25T00:00:00.0000000', N'Salario de Novembro', 2, 5000.0),
(2, '2023-11-10T00:00:00.0000000', N'Aluguel de Novembro', 1, 1200.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataLancamento', N'Descricao', N'TipoLancamento', N'Valor') AND [object_id] = OBJECT_ID(N'[TB_LANCAMENTOS]'))
    SET IDENTITY_INSERT [TB_LANCAMENTOS] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231212052408_InitialCreate', N'7.0.11');
GO

COMMIT;
GO


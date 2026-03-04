BEGIN TRANSACTION;
CREATE TABLE [TB_ARMAS] (
    [id] int NOT NULL IDENTITY,
    [nome] varchar(200) NOT NULL,
    [dano] int NOT NULL,
    CONSTRAINT [PK_TB_ARMAS] PRIMARY KEY ([id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'dano', N'nome') AND [object_id] = OBJECT_ID(N'[TB_ARMAS]'))
    SET IDENTITY_INSERT [TB_ARMAS] ON;
INSERT INTO [TB_ARMAS] ([id], [dano], [nome])
VALUES (1, 10, 'Anduril'),
(2, 50, 'Sting'),
(3, 150, 'Glamdring'),
(4, 200, 'Orcrist'),
(5, 80, 'Grond'),
(6, 99, 'Axe of Gimli'),
(7, 60, 'Espada Dos Nazgul');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'dano', N'nome') AND [object_id] = OBJECT_ID(N'[TB_ARMAS]'))
    SET IDENTITY_INSERT [TB_ARMAS] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250924004721_MigracaoArma', N'9.0.9');

COMMIT;
GO


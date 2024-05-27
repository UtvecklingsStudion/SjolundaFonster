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

CREATE TABLE [Customers] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Adress] nvarchar(max) NULL,
    [ZipCode] int NULL,
    [City] nvarchar(max) NULL,
    [Country] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [CustomerId] int NOT NULL,
    [Date] datetime2 NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Width] int NOT NULL,
    [Height] int NOT NULL,
    [Model] int NOT NULL,
    [Color] int NOT NULL,
    [UnitPrice] int NOT NULL,
    [Quantity] int NOT NULL,
    [OrderId] int NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id])
);
GO

CREATE INDEX [IX_Orders_CustomerId] ON [Orders] ([CustomerId]);
GO

CREATE INDEX [IX_Products_OrderId] ON [Products] ([OrderId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240417102717_InitialCreate', N'7.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Products].[Model]', N'ModelId', N'COLUMN';
GO

EXEC sp_rename N'[Products].[Color]', N'ColorId', N'COLUMN';
GO

ALTER TABLE [Products] ADD [ProductColorId] int NULL;
GO

ALTER TABLE [Products] ADD [ProductModelId] int NULL;
GO

CREATE TABLE [ProductColors] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Code] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ProductColors] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ProductModels] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Image] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ProductModels] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Code', N'Name') AND [object_id] = OBJECT_ID(N'[ProductColors]'))
    SET IDENTITY_INSERT [ProductColors] ON;
INSERT INTO [ProductColors] ([Id], [Code], [Name])
VALUES (1, N'#647C80', N'Öjablå'),
(2, N'#4F7D47', N'Köpenhamngrön'),
(3, N'#EAC67A', N'Sandgul'),
(4, N'#B4BCAD', N'Varmgrå'),
(5, N'#8E2011', N'Engelsk röd');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Code', N'Name') AND [object_id] = OBJECT_ID(N'[ProductColors]'))
    SET IDENTITY_INSERT [ProductColors] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Image', N'Name') AND [object_id] = OBJECT_ID(N'[ProductModels]'))
    SET IDENTITY_INSERT [ProductModels] ON;
INSERT INTO [ProductModels] ([Id], [Image], [Name])
VALUES (1, N'anno_1900', N'Anno 1900'),
(2, N'anno_1920', N'Anno 1920'),
(3, N'anno_1930', N'Anno 1930');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Image', N'Name') AND [object_id] = OBJECT_ID(N'[ProductModels]'))
    SET IDENTITY_INSERT [ProductModels] OFF;
GO

CREATE INDEX [IX_Products_ProductColorId] ON [Products] ([ProductColorId]);
GO

CREATE INDEX [IX_Products_ProductModelId] ON [Products] ([ProductModelId]);
GO

ALTER TABLE [Products] ADD CONSTRAINT [FK_Products_ProductColors_ProductColorId] FOREIGN KEY ([ProductColorId]) REFERENCES [ProductColors] ([Id]);
GO

ALTER TABLE [Products] ADD CONSTRAINT [FK_Products_ProductModels_ProductModelId] FOREIGN KEY ([ProductModelId]) REFERENCES [ProductModels] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240419145152_ColorAndModelClass', N'7.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Products] DROP CONSTRAINT [FK_Products_ProductColors_ProductColorId];
GO

ALTER TABLE [Products] DROP CONSTRAINT [FK_Products_ProductModels_ProductModelId];
GO

DROP INDEX [IX_Products_ProductColorId] ON [Products];
GO

DROP INDEX [IX_Products_ProductModelId] ON [Products];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'ProductColorId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Products] DROP COLUMN [ProductColorId];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'ProductModelId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Products] DROP COLUMN [ProductModelId];
GO

CREATE INDEX [IX_Products_ColorId] ON [Products] ([ColorId]);
GO

CREATE INDEX [IX_Products_ModelId] ON [Products] ([ModelId]);
GO

ALTER TABLE [Products] ADD CONSTRAINT [FK_Products_ProductColors_ColorId] FOREIGN KEY ([ColorId]) REFERENCES [ProductColors] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [Products] ADD CONSTRAINT [FK_Products_ProductModels_ModelId] FOREIGN KEY ([ModelId]) REFERENCES [ProductModels] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240422111011_changeWindowClass', N'7.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [ProductColors] SET [Code] = N'#F2F2EB ', [Name] = N'Stockholmsvit'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Code', N'Name') AND [object_id] = OBJECT_ID(N'[ProductColors]'))
    SET IDENTITY_INSERT [ProductColors] ON;
INSERT INTO [ProductColors] ([Id], [Code], [Name])
VALUES (6, N'#647C80', N'Öjablå');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Code', N'Name') AND [object_id] = OBJECT_ID(N'[ProductColors]'))
    SET IDENTITY_INSERT [ProductColors] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240422175923_ColorWhite', N'7.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [ProductColors] ADD [NCS] nvarchar(max) NOT NULL DEFAULT N'';
GO

UPDATE [ProductColors] SET [NCS] = N'0500-N'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [ProductColors] SET [NCS] = N'0500-N'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [ProductColors] SET [NCS] = N'0500-N'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [ProductColors] SET [NCS] = N'0500-N'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [ProductColors] SET [NCS] = N'0500-N'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [ProductColors] SET [NCS] = N'0500-N'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240426163115_ColorNCS', N'7.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240517072026_DescriptionModels', N'7.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [ProductModels] ADD [Description] nvarchar(max) NOT NULL DEFAULT N'';
GO

UPDATE [ProductModels] SET [Description] = N'Anno 1900 är en fönstermodell med två spröjs i varje fönsterbåge. Vanlint förekommande i svensk arkitektur under byggtiden kring 1900.'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [ProductModels] SET [Description] = N'Anno 1920 är en fönstermodell med en spröjs i varje fönsterbåge. Vanlint förekommande i svensk arkitektur under byggtiden kring 1920.'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [ProductModels] SET [Description] = N'Anno 1920 är en fönstermodell utan spröjs. Vanlint förekommande i svensk arkitektur under byggtiden kring 1930.'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240517072820_DescriptionModels2', N'7.0.13');
GO

COMMIT;
GO


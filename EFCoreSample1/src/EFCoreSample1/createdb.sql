IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Books] (
    [BookId] int NOT NULL IDENTITY,
    [Publisher] nvarchar(50),
    [Title] nvarchar(40),
    CONSTRAINT [PK_Books] PRIMARY KEY ([BookId])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20160914094807_InitialMigration', N'1.0.1');

GO

ALTER TABLE [Books] ADD [Isbn] nvarchar(40);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20160914095109_AddIsbn', N'1.0.1');

GO


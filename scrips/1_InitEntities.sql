IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Items] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Notes] (
    [Id] int NOT NULL IDENTITY,
    [Content] nvarchar(max) NULL,
    [ItemId] int NOT NULL,
    [Deleted] bit NOT NULL,
    CONSTRAINT [PK_Notes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Notes_Items_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Items] ([Id]) ON DELETE CASCADE
);

GO

CREATE UNIQUE INDEX [IX_Notes_ItemId] ON [Notes] ([ItemId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190813141425_InitEntities', N'2.2.6-servicing-10079');

GO
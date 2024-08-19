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

CREATE TABLE [Students] (
    [StudentId] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(max) NOT NULL,
    [MiddleName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Age] int NOT NULL,
    [RegistrationNumber] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY ([StudentId])
);
GO

CREATE TABLE [Streams] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [StudentId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Streams] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Streams_Students_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Students] ([StudentId]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Streams_StudentId] ON [Streams] ([StudentId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240819082940_Initial', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Streams] DROP CONSTRAINT [FK_Streams_Students_StudentId];
GO

DROP INDEX [IX_Streams_StudentId] ON [Streams];
GO

EXEC sp_rename N'[Streams].[StudentId]', N'StudentEntityStudentId', N'COLUMN';
GO

ALTER TABLE [Students] ADD [StreamId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
GO

CREATE INDEX [IX_Streams_StudentEntityStudentId] ON [Streams] ([StudentEntityStudentId]);
GO

ALTER TABLE [Streams] ADD CONSTRAINT [FK_Streams_Students_StudentEntityStudentId] FOREIGN KEY ([StudentEntityStudentId]) REFERENCES [Students] ([StudentId]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240819084138_create relation', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Streams] DROP CONSTRAINT [FK_Streams_Students_StudentEntityStudentId];
GO

DROP INDEX [IX_Streams_StudentEntityStudentId] ON [Streams];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Streams]') AND [c].[name] = N'StudentEntityStudentId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Streams] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Streams] DROP COLUMN [StudentEntityStudentId];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240819084258_update stream table', N'8.0.8');
GO

COMMIT;
GO


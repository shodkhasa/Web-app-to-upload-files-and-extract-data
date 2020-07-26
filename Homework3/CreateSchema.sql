IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [CityDailyCaseDatas] (
    [Id] int NOT NULL IDENTITY,
    [Death] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [Cases] int NOT NULL,
    [Test] int NOT NULL,
    [Date] datetime2 NOT NULL,
    CONSTRAINT [PK_CityDailyCaseDatas] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [CityDatas] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Pop] int NOT NULL,
    CONSTRAINT [PK_CityDatas] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200722073721_InitialSchema', N'3.1.6');

GO


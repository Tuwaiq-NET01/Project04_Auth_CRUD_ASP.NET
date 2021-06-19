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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    CREATE TABLE [Books] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Url] nvarchar(max) NULL,
        CONSTRAINT [PK_Books] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    CREATE TABLE [FlashCards] (
        [id] int NOT NULL IDENTITY,
        [Question] nvarchar(max) NOT NULL,
        [Answer] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_FlashCards] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    CREATE TABLE [Quotes] (
        [Id] int NOT NULL IDENTITY,
        [Body] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Quotes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NULL,
        [Password] nvarchar(max) NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    CREATE TABLE [Chapters] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NULL,
        [BookId] int NOT NULL,
        CONSTRAINT [PK_Chapters] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Chapters_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    CREATE TABLE [Facts] (
        [Id] int NOT NULL IDENTITY,
        [Body] nvarchar(max) NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [Attachment] nvarchar(max) NULL,
        [UserId] int NOT NULL,
        CONSTRAINT [PK_Facts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Facts_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    CREATE TABLE [Motivations] (
        [id] int NOT NULL IDENTITY,
        [Body] nvarchar(max) NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UserId] int NOT NULL,
        CONSTRAINT [PK_Motivations] PRIMARY KEY ([id]),
        CONSTRAINT [FK_Motivations_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    CREATE TABLE [ChapterChunks] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Body] nvarchar(max) NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [CurrentPage] int NOT NULL,
        [ChapterId] int NOT NULL,
        CONSTRAINT [PK_ChapterChunks] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ChapterChunks_Chapters_ChapterId] FOREIGN KEY ([ChapterId]) REFERENCES [Chapters] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'Url') AND [object_id] = OBJECT_ID(N'[Books]'))
        SET IDENTITY_INSERT [Books] ON;
    EXEC(N'INSERT INTO [Books] ([Id], [Name], [Url])
    VALUES (1, N''C# in Depth, Fourth Edition'', N''https://www.oreilly.com/library/view/c-in-depth/9781617294532/''),
    (2, N''Head First C#, 4th Editio'', N''https://www.oreilly.com/library/view/head-first-c/9781491976692/'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'Url') AND [object_id] = OBJECT_ID(N'[Books]'))
        SET IDENTITY_INSERT [Books] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'Answer', N'Question') AND [object_id] = OBJECT_ID(N'[FlashCards]'))
        SET IDENTITY_INSERT [FlashCards] ON;
    EXEC(N'INSERT INTO [FlashCards] ([id], [Answer], [Question])
    VALUES (1, N''The abstract keyword enables you to create classes and class members that are incomplete and must be implemented in a derived class. '', N''What is an abstract Keyword?''),
    (2, N''A delegate is a reference type that can be used to encapsulate a named or an anonymous method.'', N''Delegate '')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'Answer', N'Question') AND [object_id] = OBJECT_ID(N'[FlashCards]'))
        SET IDENTITY_INSERT [FlashCards] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Body') AND [object_id] = OBJECT_ID(N'[Quotes]'))
        SET IDENTITY_INSERT [Quotes] ON;
    EXEC(N'INSERT INTO [Quotes] ([Id], [Body])
    VALUES (1, N''Stay Focused''),
    (2, N''Keep it going'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Body') AND [object_id] = OBJECT_ID(N'[Quotes]'))
        SET IDENTITY_INSERT [Quotes] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Name', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    EXEC(N'INSERT INTO [Users] ([Id], [Email], [Name], [Password])
    VALUES (1, N''Mansoviic@gmail.com'', N''Mansovic'', N''P@assWord123''),
    (2, N''Mansoviic2@gmail.com'', N''Mansovic2'', N''P@assWord1232'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Name', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BookId', N'Title') AND [object_id] = OBJECT_ID(N'[Chapters]'))
        SET IDENTITY_INSERT [Chapters] ON;
    EXEC(N'INSERT INTO [Chapters] ([Id], [BookId], [Title])
    VALUES (1, 1, N''Introduction''),
    (2, 1, N''Deep Coding'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BookId', N'Title') AND [object_id] = OBJECT_ID(N'[Chapters]'))
        SET IDENTITY_INSERT [Chapters] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Attachment', N'Body', N'CreatedAt', N'UserId') AND [object_id] = OBJECT_ID(N'[Facts]'))
        SET IDENTITY_INSERT [Facts] ON;
    EXEC(N'INSERT INTO [Facts] ([Id], [Attachment], [Body], [CreatedAt], [UserId])
    VALUES (2, N''https://edu.rsc.org/resources/tyndall-effect-why-the-sky-is-blue/1877.article'', N''Tyndall effect- why the sky is blue'', ''2021-06-19T16:40:16.6792378Z'', 1),
    (1, N''https://www.w3schools.com/cs/cs_oop.asp'', N''C# is OOP'', ''2021-06-19T16:40:16.6791576Z'', 2)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Attachment', N'Body', N'CreatedAt', N'UserId') AND [object_id] = OBJECT_ID(N'[Facts]'))
        SET IDENTITY_INSERT [Facts] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'Body', N'CreatedAt', N'UserId') AND [object_id] = OBJECT_ID(N'[Motivations]'))
        SET IDENTITY_INSERT [Motivations] ON;
    EXEC(N'INSERT INTO [Motivations] ([id], [Body], [CreatedAt], [UserId])
    VALUES (2, N''If you really want the key to success, start by doing the opposite of what everyone else is doing. —Brad Szollose'', ''2021-06-19T16:40:16.6790074Z'', 1),
    (1, N''Too many of us are not living our dreams because we are living our fears. —Les Brown'', ''2021-06-19T16:40:16.6789179Z'', 2)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'Body', N'CreatedAt', N'UserId') AND [object_id] = OBJECT_ID(N'[Motivations]'))
        SET IDENTITY_INSERT [Motivations] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Body', N'ChapterId', N'CreatedAt', N'CurrentPage', N'Title') AND [object_id] = OBJECT_ID(N'[ChapterChunks]'))
        SET IDENTITY_INSERT [ChapterChunks] ON;
    EXEC(N'INSERT INTO [ChapterChunks] ([Id], [Body], [ChapterId], [CreatedAt], [CurrentPage], [Title])
    VALUES (2, N''a small intro '', 1, ''2021-06-19T16:40:16.6800956Z'', 12, N''intro'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Body', N'ChapterId', N'CreatedAt', N'CurrentPage', N'Title') AND [object_id] = OBJECT_ID(N'[ChapterChunks]'))
        SET IDENTITY_INSERT [ChapterChunks] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Body', N'ChapterId', N'CreatedAt', N'CurrentPage', N'Title') AND [object_id] = OBJECT_ID(N'[ChapterChunks]'))
        SET IDENTITY_INSERT [ChapterChunks] ON;
    EXEC(N'INSERT INTO [ChapterChunks] ([Id], [Body], [ChapterId], [CreatedAt], [CurrentPage], [Title])
    VALUES (1, N''what is deep coding and why'', 2, ''2021-06-19T16:40:16.6800154Z'', 23, N''Deep Coding'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Body', N'ChapterId', N'CreatedAt', N'CurrentPage', N'Title') AND [object_id] = OBJECT_ID(N'[ChapterChunks]'))
        SET IDENTITY_INSERT [ChapterChunks] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    CREATE INDEX [IX_ChapterChunks_ChapterId] ON [ChapterChunks] ([ChapterId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    CREATE INDEX [IX_Chapters_BookId] ON [Chapters] ([BookId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    CREATE INDEX [IX_Facts_UserId] ON [Facts] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    CREATE INDEX [IX_Motivations_UserId] ON [Motivations] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619164017_initialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210619164017_initialCreate', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619171744_DateFormat')
BEGIN
    EXEC(N'UPDATE [ChapterChunks] SET [CreatedAt] = ''2021-06-19T20:17:44.1936258+03:00''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619171744_DateFormat')
BEGIN
    EXEC(N'UPDATE [ChapterChunks] SET [CreatedAt] = ''2021-06-19T20:17:44.1936749+03:00''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619171744_DateFormat')
BEGIN
    EXEC(N'UPDATE [Facts] SET [CreatedAt] = ''2021-06-19T20:17:44.1931444+03:00''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619171744_DateFormat')
BEGIN
    EXEC(N'UPDATE [Facts] SET [CreatedAt] = ''2021-06-19T20:17:44.1931942+03:00''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619171744_DateFormat')
BEGIN
    EXEC(N'UPDATE [Motivations] SET [CreatedAt] = ''2021-06-19T20:17:44.1923265+03:00''
    WHERE [id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619171744_DateFormat')
BEGIN
    EXEC(N'UPDATE [Motivations] SET [CreatedAt] = ''2021-06-19T20:17:44.1930509+03:00''
    WHERE [id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210619171744_DateFormat')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210619171744_DateFormat', N'5.0.7');
END;
GO

COMMIT;
GO


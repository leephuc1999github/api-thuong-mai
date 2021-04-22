IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318042937_init')
BEGIN
    CREATE TABLE [AppRoles] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        [NormalizedName] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [Description] nvarchar(200) NOT NULL,
        CONSTRAINT [PK_AppRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318042937_init')
BEGIN
    CREATE TABLE [AppUserLogins] (
        [UserId] uniqueidentifier NOT NULL,
        [LoginProvider] nvarchar(max) NULL,
        [ProviderKey] nvarchar(max) NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        CONSTRAINT [PK_AppUserLogins] PRIMARY KEY ([UserId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318042937_init')
BEGIN
    CREATE TABLE [AppUserRoles] (
        [UserId] uniqueidentifier NOT NULL,
        [RoleId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_AppUserRoles] PRIMARY KEY ([UserId], [RoleId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318042937_init')
BEGIN
    CREATE TABLE [AppUsers] (
        [Id] uniqueidentifier NOT NULL,
        [UserName] nvarchar(max) NULL,
        [NormalizedUserName] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [NormalizedEmail] nvarchar(max) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        [FirstName] nvarchar(200) NOT NULL,
        [LastName] nvarchar(200) NOT NULL,
        [Dob] datetime2 NOT NULL,
        CONSTRAINT [PK_AppUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318042937_init')
BEGIN
    CREATE TABLE [AppUserTokens] (
        [UserId] uniqueidentifier NOT NULL,
        [LoginProvider] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AppUserTokens] PRIMARY KEY ([UserId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318042937_init')
BEGIN
    CREATE TABLE [RoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] uniqueidentifier NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_RoleClaims] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318042937_init')
BEGIN
    CREATE TABLE [UserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] uniqueidentifier NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_UserClaims] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318042937_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Description', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AppRoles]'))
        SET IDENTITY_INSERT [AppRoles] ON;
    INSERT INTO [AppRoles] ([Id], [ConcurrencyStamp], [Description], [Name], [NormalizedName])
    VALUES ('8d04dce2-969a-435d-bba4-df3f325983dc', N'd037bce9-6847-44ae-9766-fa6ab5aa43c1', N'Administrator role', N'admin', N'admin');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Description', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AppRoles]'))
        SET IDENTITY_INSERT [AppRoles] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318042937_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'RoleId') AND [object_id] = OBJECT_ID(N'[AppUserRoles]'))
        SET IDENTITY_INSERT [AppUserRoles] ON;
    INSERT INTO [AppUserRoles] ([UserId], [RoleId])
    VALUES ('69bd714f-9576-45ba-b5b7-f00649be00de', '8d04dce2-969a-435d-bba4-df3f325983dc');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'RoleId') AND [object_id] = OBJECT_ID(N'[AppUserRoles]'))
        SET IDENTITY_INSERT [AppUserRoles] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318042937_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Dob', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AppUsers]'))
        SET IDENTITY_INSERT [AppUsers] ON;
    INSERT INTO [AppUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Dob], [Email], [EmailConfirmed], [FirstName], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
    VALUES ('69bd714f-9576-45ba-b5b7-f00649be00de', 0, N'1330c67e-7cdf-4eb2-aeed-5e4c3274d925', '2020-01-31T00:00:00.0000000', N'tedu.international@gmail.com', CAST(1 AS bit), N'Toan', N'Bach', CAST(0 AS bit), NULL, N'tedu.international@gmail.com', N'admin', N'AQAAAAEAACcQAAAAEIgNwMRXpH2mY6FRCJ8lqeFY5Z8gvdxBm3a68PDFmRTzCx4ySSCy96Ux1uK8A5iciQ==', NULL, CAST(0 AS bit), N'', CAST(0 AS bit), N'admin');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Dob', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AppUsers]'))
        SET IDENTITY_INSERT [AppUsers] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318042937_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210318042937_init', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210319113138_add-claims-identity')
BEGIN
    ALTER TABLE [UserClaims] DROP CONSTRAINT [PK_UserClaims];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210319113138_add-claims-identity')
BEGIN
    ALTER TABLE [RoleClaims] DROP CONSTRAINT [PK_RoleClaims];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210319113138_add-claims-identity')
BEGIN
    EXEC sp_rename N'[UserClaims]', N'AppUserClaims';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210319113138_add-claims-identity')
BEGIN
    EXEC sp_rename N'[RoleClaims]', N'AppRoleClaims';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210319113138_add-claims-identity')
BEGIN
    ALTER TABLE [AppUserClaims] ADD CONSTRAINT [PK_AppUserClaims] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210319113138_add-claims-identity')
BEGIN
    ALTER TABLE [AppRoleClaims] ADD CONSTRAINT [PK_AppRoleClaims] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210319113138_add-claims-identity')
BEGIN
    UPDATE [AppRoles] SET [ConcurrencyStamp] = N'f1ac2dcf-0f91-4a3d-9da5-ae2a34030b68'
    WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210319113138_add-claims-identity')
BEGIN
    UPDATE [AppUsers] SET [ConcurrencyStamp] = N'adae74b1-8280-425c-8771-10e5dc866a18', [PasswordHash] = N'AQAAAAEAACcQAAAAEOtfUZKD3jCXQq7Gu+IpYE2K0ZMTdJyRjPELcCstVLcDrHWGXzbVzeh/ad9eaB1nRQ=='
    WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210319113138_add-claims-identity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210319113138_add-claims-identity', N'3.1.1');
END;

GO


IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE TABLE [AppConfigs] (
        [Key] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_AppConfigs] PRIMARY KEY ([Key])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE TABLE [Categories] (
        [Id] int NOT NULL IDENTITY,
        [SortOrder] int NOT NULL,
        [IsShowOnHome] bit NOT NULL,
        [ParentId] int NULL,
        [Status] int NOT NULL DEFAULT 1,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE TABLE [Contacts] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(200) NOT NULL,
        [Email] nvarchar(200) NOT NULL,
        [PhoneNumber] nvarchar(200) NOT NULL,
        [Message] nvarchar(max) NOT NULL,
        [Status] int NOT NULL,
        CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE TABLE [Languages] (
        [Id] varchar(5) NOT NULL,
        [Name] nvarchar(20) NOT NULL,
        [IsDefault] bit NOT NULL,
        CONSTRAINT [PK_Languages] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE TABLE [Orders] (
        [Id] int NOT NULL IDENTITY,
        [OrderDate] datetime2 NOT NULL DEFAULT '2021-03-18T09:06:55.7097164+07:00',
        [UserId] uniqueidentifier NOT NULL,
        [ShipName] nvarchar(200) NOT NULL,
        [ShipAddress] nvarchar(200) NOT NULL,
        [ShipEmail] varchar(50) NOT NULL,
        [ShipPhoneNumber] nvarchar(200) NOT NULL,
        [Status] int NOT NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL IDENTITY,
        [Price] decimal(18,2) NOT NULL,
        [OriginalPrice] decimal(18,2) NOT NULL,
        [Stock] int NOT NULL DEFAULT 0,
        [ViewCount] int NOT NULL DEFAULT 0,
        [DateCreated] datetime2 NOT NULL,
        [SeoAlias] nvarchar(max) NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE TABLE [Promotions] (
        [Id] int NOT NULL IDENTITY,
        [FromDate] datetime2 NOT NULL,
        [ToDate] datetime2 NOT NULL,
        [ApplyForAll] bit NOT NULL,
        [DiscountPercent] int NULL,
        [DiscountAmount] decimal(18,2) NULL,
        [ProductIds] nvarchar(max) NULL,
        [ProductCategoryIds] nvarchar(max) NULL,
        [Status] int NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Promotions] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE TABLE [Transactions] (
        [Id] int NOT NULL IDENTITY,
        [UserId] uniqueidentifier NOT NULL,
        [TransactionDate] datetime2 NOT NULL,
        [ExternalTransactionId] nvarchar(max) NULL,
        [Amount] decimal(18,2) NOT NULL,
        [Fee] decimal(18,2) NOT NULL,
        [Result] nvarchar(max) NULL,
        [Message] nvarchar(max) NULL,
        [Status] int NOT NULL,
        [Provider] nvarchar(max) NULL,
        CONSTRAINT [PK_Transactions] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE TABLE [CategoryTranslations] (
        [Id] int NOT NULL IDENTITY,
        [CategoryId] int NOT NULL,
        [Name] nvarchar(200) NOT NULL,
        [SeoDescription] nvarchar(500) NULL,
        [SeoTitle] nvarchar(200) NULL,
        [LanguageId] varchar(5) NOT NULL,
        [SeoAlias] nvarchar(200) NOT NULL,
        CONSTRAINT [PK_CategoryTranslations] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CategoryTranslations_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_CategoryTranslations_Languages_LanguageId] FOREIGN KEY ([LanguageId]) REFERENCES [Languages] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE TABLE [Carts] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [Quantity] int NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        [UserId] uniqueidentifier NOT NULL,
        [DateCreated] datetime2 NOT NULL,
        CONSTRAINT [PK_Carts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Carts_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE TABLE [OrderDetails] (
        [OrderId] int NOT NULL,
        [ProductId] int NOT NULL,
        [Quantity] int NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_OrderDetails] PRIMARY KEY ([OrderId], [ProductId]),
        CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_OrderDetails_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE TABLE [ProductInCategories] (
        [ProductId] int NOT NULL,
        [CategoryId] int NOT NULL,
        CONSTRAINT [PK_ProductInCategories] PRIMARY KEY ([CategoryId], [ProductId]),
        CONSTRAINT [FK_ProductInCategories_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ProductInCategories_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE TABLE [ProductTranslations] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [Name] nvarchar(200) NOT NULL,
        [Description] nvarchar(max) NULL,
        [Details] nvarchar(500) NULL,
        [SeoDescription] nvarchar(max) NULL,
        [SeoTitle] nvarchar(max) NULL,
        [SeoAlias] nvarchar(200) NOT NULL,
        [LanguageId] varchar(5) NOT NULL,
        CONSTRAINT [PK_ProductTranslations] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductTranslations_Languages_LanguageId] FOREIGN KEY ([LanguageId]) REFERENCES [Languages] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ProductTranslations_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Key', N'Value') AND [object_id] = OBJECT_ID(N'[AppConfigs]'))
        SET IDENTITY_INSERT [AppConfigs] ON;
    INSERT INTO [AppConfigs] ([Key], [Value])
    VALUES (N'HomeTitle', N'This is home page of eShopSolution'),
    (N'HomeKeyword', N'This is keyword of eShopSolution'),
    (N'HomeDescription', N'This is description of eShopSolution');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Key', N'Value') AND [object_id] = OBJECT_ID(N'[AppConfigs]'))
        SET IDENTITY_INSERT [AppConfigs] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsShowOnHome', N'ParentId', N'SortOrder', N'Status') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    INSERT INTO [Categories] ([Id], [IsShowOnHome], [ParentId], [SortOrder], [Status])
    VALUES (1, CAST(1 AS bit), NULL, 1, 1),
    (2, CAST(1 AS bit), NULL, 2, 1);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsShowOnHome', N'ParentId', N'SortOrder', N'Status') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsDefault', N'Name') AND [object_id] = OBJECT_ID(N'[Languages]'))
        SET IDENTITY_INSERT [Languages] ON;
    INSERT INTO [Languages] ([Id], [IsDefault], [Name])
    VALUES ('vi-VN', CAST(1 AS bit), N'Tiếng Việt'),
    ('en-US', CAST(0 AS bit), N'English');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsDefault', N'Name') AND [object_id] = OBJECT_ID(N'[Languages]'))
        SET IDENTITY_INSERT [Languages] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateCreated', N'OriginalPrice', N'Price', N'SeoAlias') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] ON;
    INSERT INTO [Products] ([Id], [DateCreated], [OriginalPrice], [Price], [SeoAlias])
    VALUES (1, '2021-03-18T09:06:55.7235775+07:00', 100000.0, 200000.0, NULL);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateCreated', N'OriginalPrice', N'Price', N'SeoAlias') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'LanguageId', N'Name', N'SeoAlias', N'SeoDescription', N'SeoTitle') AND [object_id] = OBJECT_ID(N'[CategoryTranslations]'))
        SET IDENTITY_INSERT [CategoryTranslations] ON;
    INSERT INTO [CategoryTranslations] ([Id], [CategoryId], [LanguageId], [Name], [SeoAlias], [SeoDescription], [SeoTitle])
    VALUES (1, 1, 'vi-VN', N'Áo nam', N'ao-nam', N'Sản phẩm áo thời trang nam', N'Sản phẩm áo thời trang nam'),
    (3, 2, 'vi-VN', N'Áo nữ', N'ao-nu', N'Sản phẩm áo thời trang nữ', N'Sản phẩm áo thời trang women'),
    (2, 1, 'en-US', N'Men Shirt', N'men-shirt', N'The shirt products for men', N'The shirt products for men'),
    (4, 2, 'en-US', N'Women Shirt', N'women-shirt', N'The shirt products for women', N'The shirt products for women');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'LanguageId', N'Name', N'SeoAlias', N'SeoDescription', N'SeoTitle') AND [object_id] = OBJECT_ID(N'[CategoryTranslations]'))
        SET IDENTITY_INSERT [CategoryTranslations] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryId', N'ProductId') AND [object_id] = OBJECT_ID(N'[ProductInCategories]'))
        SET IDENTITY_INSERT [ProductInCategories] ON;
    INSERT INTO [ProductInCategories] ([CategoryId], [ProductId])
    VALUES (1, 1);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryId', N'ProductId') AND [object_id] = OBJECT_ID(N'[ProductInCategories]'))
        SET IDENTITY_INSERT [ProductInCategories] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Details', N'LanguageId', N'Name', N'ProductId', N'SeoAlias', N'SeoDescription', N'SeoTitle') AND [object_id] = OBJECT_ID(N'[ProductTranslations]'))
        SET IDENTITY_INSERT [ProductTranslations] ON;
    INSERT INTO [ProductTranslations] ([Id], [Description], [Details], [LanguageId], [Name], [ProductId], [SeoAlias], [SeoDescription], [SeoTitle])
    VALUES (1, N'Áo sơ mi nam trắng Việt Tiến', N'Áo sơ mi nam trắng Việt Tiến', 'vi-VN', N'Áo sơ mi nam trắng Việt Tiến', 1, N'ao-so-mi-nam-trang-viet-tien', N'Áo sơ mi nam trắng Việt Tiến', N'Áo sơ mi nam trắng Việt Tiến'),
    (2, N'Viet Tien Men T-Shirt', N'Viet Tien Men T-Shirt', 'en-US', N'Viet Tien Men T-Shirt', 1, N'viet-tien-men-t-shirt', N'Viet Tien Men T-Shirt', N'Viet Tien Men T-Shirt');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Details', N'LanguageId', N'Name', N'ProductId', N'SeoAlias', N'SeoDescription', N'SeoTitle') AND [object_id] = OBJECT_ID(N'[ProductTranslations]'))
        SET IDENTITY_INSERT [ProductTranslations] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE INDEX [IX_Carts_ProductId] ON [Carts] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE INDEX [IX_CategoryTranslations_CategoryId] ON [CategoryTranslations] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE INDEX [IX_CategoryTranslations_LanguageId] ON [CategoryTranslations] ([LanguageId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE INDEX [IX_OrderDetails_ProductId] ON [OrderDetails] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE INDEX [IX_ProductInCategories_ProductId] ON [ProductInCategories] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE INDEX [IX_ProductTranslations_LanguageId] ON [ProductTranslations] ([LanguageId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    CREATE INDEX [IX_ProductTranslations_ProductId] ON [ProductTranslations] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210318020656_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210318020656_init', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210320072400_add-table-product-image-eshop')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'OrderDate');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Orders] ALTER COLUMN [OrderDate] datetime2 NOT NULL;
    ALTER TABLE [Orders] ADD DEFAULT '2021-03-20T14:23:59.5018023+07:00' FOR [OrderDate];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210320072400_add-table-product-image-eshop')
BEGIN
    CREATE TABLE [ProductImages] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [ImagePath] nvarchar(200) NOT NULL,
        [Caption] nvarchar(200) NULL,
        [IsDefault] bit NOT NULL,
        [DateCreated] datetime2 NOT NULL,
        [SortOrder] int NOT NULL,
        [FileSize] int NOT NULL,
        CONSTRAINT [PK_ProductImages] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductImages_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210320072400_add-table-product-image-eshop')
BEGIN
    UPDATE [Categories] SET [Status] = 1
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210320072400_add-table-product-image-eshop')
BEGIN
    UPDATE [Categories] SET [Status] = 1
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210320072400_add-table-product-image-eshop')
BEGIN
    UPDATE [Products] SET [DateCreated] = '2021-03-20T14:23:59.5313534+07:00'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210320072400_add-table-product-image-eshop')
BEGIN
    CREATE INDEX [IX_ProductImages_ProductId] ON [ProductImages] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210320072400_add-table-product-image-eshop')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210320072400_add-table-product-image-eshop', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210323103323_add-method-handle-image-eshopdbcontext')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductImages]') AND [c].[name] = N'FileSize');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ProductImages] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [ProductImages] ALTER COLUMN [FileSize] bigint NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210323103323_add-method-handle-image-eshopdbcontext')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'OrderDate');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Orders] ALTER COLUMN [OrderDate] datetime2 NOT NULL;
    ALTER TABLE [Orders] ADD DEFAULT '2021-03-23T17:33:22.5826985+07:00' FOR [OrderDate];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210323103323_add-method-handle-image-eshopdbcontext')
BEGIN
    UPDATE [Categories] SET [Status] = 1
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210323103323_add-method-handle-image-eshopdbcontext')
BEGIN
    UPDATE [Categories] SET [Status] = 1
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210323103323_add-method-handle-image-eshopdbcontext')
BEGIN
    UPDATE [Products] SET [DateCreated] = '2021-03-23T17:33:22.5982895+07:00'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210323103323_add-method-handle-image-eshopdbcontext')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210323103323_add-method-handle-image-eshopdbcontext', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210324074119_add-slide-eshopdbcontext')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'OrderDate');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Orders] ALTER COLUMN [OrderDate] datetime2 NOT NULL;
    ALTER TABLE [Orders] ADD DEFAULT '2021-03-24T14:41:18.8407319+07:00' FOR [OrderDate];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210324074119_add-slide-eshopdbcontext')
BEGIN
    CREATE TABLE [Slides] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(200) NOT NULL,
        [Description] nvarchar(200) NOT NULL,
        [Url] nvarchar(200) NOT NULL,
        [Image] nvarchar(200) NOT NULL,
        [SortOrder] int NOT NULL,
        [Status] int NOT NULL,
        CONSTRAINT [PK_Slides] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210324074119_add-slide-eshopdbcontext')
BEGIN
    UPDATE [Categories] SET [Status] = 1
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210324074119_add-slide-eshopdbcontext')
BEGIN
    UPDATE [Categories] SET [Status] = 1
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210324074119_add-slide-eshopdbcontext')
BEGIN
    UPDATE [Products] SET [DateCreated] = '2021-03-24T14:41:18.8571951+07:00'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210324074119_add-slide-eshopdbcontext')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210324074119_add-slide-eshopdbcontext', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210404103021_add-field-Icon-for-language')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'OrderDate');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Orders] ALTER COLUMN [OrderDate] datetime2 NOT NULL;
    ALTER TABLE [Orders] ADD DEFAULT '2021-04-04T17:30:20.4346246+07:00' FOR [OrderDate];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210404103021_add-field-Icon-for-language')
BEGIN
    ALTER TABLE [Languages] ADD [Icon] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210404103021_add-field-Icon-for-language')
BEGIN
    UPDATE [Categories] SET [Status] = 1
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210404103021_add-field-Icon-for-language')
BEGIN
    UPDATE [Categories] SET [Status] = 1
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210404103021_add-field-Icon-for-language')
BEGIN
    UPDATE [Products] SET [DateCreated] = '2021-04-04T17:30:20.4512803+07:00'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210404103021_add-field-Icon-for-language')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210404103021_add-field-Icon-for-language', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210412080236_add-menu-item')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'OrderDate');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Orders] ALTER COLUMN [OrderDate] datetime2 NOT NULL;
    ALTER TABLE [Orders] ADD DEFAULT '2021-04-12T15:02:35.6661427+07:00' FOR [OrderDate];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210412080236_add-menu-item')
BEGIN
    CREATE TABLE [MenuItems] (
        [Id] int NOT NULL IDENTITY,
        [Text] nvarchar(max) NULL,
        [Icon] nvarchar(max) NULL,
        [State] int NOT NULL,
        [ParentId] int NULL,
        CONSTRAINT [PK_MenuItems] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210412080236_add-menu-item')
BEGIN
    UPDATE [Categories] SET [Status] = 1
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210412080236_add-menu-item')
BEGIN
    UPDATE [Categories] SET [Status] = 1
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210412080236_add-menu-item')
BEGIN
    UPDATE [Products] SET [DateCreated] = '2021-04-12T15:02:35.6828103+07:00'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210412080236_add-menu-item')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210412080236_add-menu-item', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210412085407_update-menu-item')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'OrderDate');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Orders] ALTER COLUMN [OrderDate] datetime2 NOT NULL;
    ALTER TABLE [Orders] ADD DEFAULT '2021-04-12T15:54:07.3080443+07:00' FOR [OrderDate];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210412085407_update-menu-item')
BEGIN
    ALTER TABLE [MenuItems] ADD [SortOrder] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210412085407_update-menu-item')
BEGIN
    UPDATE [Categories] SET [Status] = 1
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210412085407_update-menu-item')
BEGIN
    UPDATE [Categories] SET [Status] = 1
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210412085407_update-menu-item')
BEGIN
    UPDATE [Products] SET [DateCreated] = '2021-04-12T15:54:07.3271774+07:00'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210412085407_update-menu-item')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210412085407_update-menu-item', N'3.1.1');
END;

GO


IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210218072444_initial')
BEGIN
    CREATE TABLE [DoiTacs] (
        [ID] int NOT NULL IDENTITY,
        [Created] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [Modified] datetime2 NOT NULL,
        [ModifiedBy] nvarchar(max) NULL,
        [CMT] nvarchar(max) NULL,
        [NamSinh] int NOT NULL,
        [SDT] nvarchar(max) NULL,
        CONSTRAINT [PK_DoiTacs] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210218072444_initial')
BEGIN
    CREATE TABLE [HopDongs] (
        [ID] int NOT NULL IDENTITY,
        [Created] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [Modified] datetime2 NOT NULL,
        [ModifiedBy] nvarchar(max) NULL,
        [NgayKyHopDong] datetime2 NOT NULL,
        CONSTRAINT [PK_HopDongs] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210218072444_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210218072444_initial', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210218073445_add-table-nhanvien-nhanviendaidien-ky')
BEGIN
    CREATE TABLE [NhanViens] (
        [ID] int NOT NULL IDENTITY,
        [Created] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [Modified] datetime2 NOT NULL,
        [ModifiedBy] nvarchar(max) NULL,
        [CMT] nvarchar(max) NULL,
        [Ten] nvarchar(max) NULL,
        [DiaChi] nvarchar(max) NULL,
        [NgaySinh] datetime2 NULL,
        [SDT] nvarchar(max) NULL,
        [Discriminator] nvarchar(max) NOT NULL,
        [ChucVu] nvarchar(max) NULL,
        [LinhVuc] nvarchar(max) NULL,
        CONSTRAINT [PK_NhanViens] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210218073445_add-table-nhanvien-nhanviendaidien-ky')
BEGIN
    CREATE TABLE [Kys] (
        [ID] int NOT NULL IDENTITY,
        [Created] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [Modified] datetime2 NOT NULL,
        [ModifiedBy] nvarchar(max) NULL,
        [DoiTacId] int NULL,
        [HopDongId] int NULL,
        [NhanVienDaiDienId] int NULL,
        CONSTRAINT [PK_Kys] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Kys_DoiTacs_DoiTacId] FOREIGN KEY ([DoiTacId]) REFERENCES [DoiTacs] ([ID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Kys_HopDongs_HopDongId] FOREIGN KEY ([HopDongId]) REFERENCES [HopDongs] ([ID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Kys_NhanViens_NhanVienDaiDienId] FOREIGN KEY ([NhanVienDaiDienId]) REFERENCES [NhanViens] ([ID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210218073445_add-table-nhanvien-nhanviendaidien-ky')
BEGIN
    CREATE INDEX [IX_Kys_DoiTacId] ON [Kys] ([DoiTacId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210218073445_add-table-nhanvien-nhanviendaidien-ky')
BEGIN
    CREATE INDEX [IX_Kys_HopDongId] ON [Kys] ([HopDongId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210218073445_add-table-nhanvien-nhanviendaidien-ky')
BEGIN
    CREATE INDEX [IX_Kys_NhanVienDaiDienId] ON [Kys] ([NhanVienDaiDienId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210218073445_add-table-nhanvien-nhanviendaidien-ky')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210218073445_add-table-nhanvien-nhanviendaidien-ky', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    DROP TABLE [Kys];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    ALTER TABLE [NhanViens] ADD [GiamDocId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    ALTER TABLE [NhanViens] ADD [KhuVucQuanLy] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    ALTER TABLE [NhanViens] ADD [NhanVienDaiDien_ChucVu] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    ALTER TABLE [NhanViens] ADD [NhanVienQuanLy_ChucVu] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    ALTER TABLE [NhanViens] ADD [NhanVienQuanLy_KhuVucQuanLy] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    ALTER TABLE [HopDongs] ADD [DoiTacId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    ALTER TABLE [HopDongs] ADD [NhanVienDaiDienId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE TABLE [CuaHangs] (
        [ID] int NOT NULL IDENTITY,
        [Created] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [Modified] datetime2 NOT NULL,
        [ModifiedBy] nvarchar(max) NULL,
        [Ten] nvarchar(max) NULL,
        [DienTich] real NULL,
        [ViTri] nvarchar(max) NULL,
        [NhanVienQuanLyId] int NULL,
        CONSTRAINT [PK_CuaHangs] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_CuaHangs_NhanViens_NhanVienQuanLyId] FOREIGN KEY ([NhanVienQuanLyId]) REFERENCES [NhanViens] ([ID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE TABLE [GiamDocs] (
        [ID] int NOT NULL IDENTITY,
        [Created] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [Modified] datetime2 NOT NULL,
        [ModifiedBy] nvarchar(max) NULL,
        [CMT] nvarchar(max) NULL,
        [Ten] nvarchar(max) NULL,
        [NamKinhNghiem] int NOT NULL,
        [SDT] nvarchar(max) NULL,
        CONSTRAINT [PK_GiamDocs] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE TABLE [MatHangs] (
        [ID] int NOT NULL IDENTITY,
        [Created] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [Modified] datetime2 NOT NULL,
        [ModifiedBy] nvarchar(max) NULL,
        [Ten] nvarchar(max) NULL,
        [Loai] nvarchar(max) NULL,
        [SoLuong] int NOT NULL,
        CONSTRAINT [PK_MatHangs] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE TABLE [ChiNhanhs] (
        [ID] int NOT NULL IDENTITY,
        [Created] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [Modified] datetime2 NOT NULL,
        [ModifiedBy] nvarchar(max) NULL,
        [GioHoatDong] nvarchar(max) NULL,
        [TenChiNhanh] nvarchar(max) NULL,
        [GiamDocId] int NULL,
        CONSTRAINT [PK_ChiNhanhs] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_ChiNhanhs_GiamDocs_GiamDocId] FOREIGN KEY ([GiamDocId]) REFERENCES [GiamDocs] ([ID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE TABLE [KinhDoanhs] (
        [ID] int NOT NULL IDENTITY,
        [Created] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [Modified] datetime2 NOT NULL,
        [ModifiedBy] nvarchar(max) NULL,
        [CuaHangId] int NULL,
        [MatHangId] int NULL,
        CONSTRAINT [PK_KinhDoanhs] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_KinhDoanhs_CuaHangs_CuaHangId] FOREIGN KEY ([CuaHangId]) REFERENCES [CuaHangs] ([ID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_KinhDoanhs_MatHangs_MatHangId] FOREIGN KEY ([MatHangId]) REFERENCES [MatHangs] ([ID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE TABLE [TinhThanhs] (
        [ID] int NOT NULL IDENTITY,
        [Created] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [Modified] datetime2 NOT NULL,
        [ModifiedBy] nvarchar(max) NULL,
        [MaTinhThanh] int NOT NULL,
        [TenTinhThanh] nvarchar(max) NULL,
        [ThanhPho] nvarchar(max) NULL,
        [ChiNhanhId] int NULL,
        CONSTRAINT [PK_TinhThanhs] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_TinhThanhs_ChiNhanhs_ChiNhanhId] FOREIGN KEY ([ChiNhanhId]) REFERENCES [ChiNhanhs] ([ID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE TABLE [KhachHangs] (
        [ID] int NOT NULL IDENTITY,
        [Created] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [Modified] datetime2 NOT NULL,
        [ModifiedBy] nvarchar(max) NULL,
        [CMT] nvarchar(max) NULL,
        [Ten] nvarchar(max) NULL,
        [NamSinh] int NOT NULL,
        [SDT] nvarchar(max) NULL,
        [TinhThanhId] int NULL,
        CONSTRAINT [PK_KhachHangs] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_KhachHangs_TinhThanhs_TinhThanhId] FOREIGN KEY ([TinhThanhId]) REFERENCES [TinhThanhs] ([ID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE TABLE [GiamSats] (
        [ID] int NOT NULL IDENTITY,
        [Created] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [Modified] datetime2 NOT NULL,
        [ModifiedBy] nvarchar(max) NULL,
        [KhachHangId] int NULL,
        [NhanVienBaoVeId] int NULL,
        CONSTRAINT [PK_GiamSats] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_GiamSats_KhachHangs_KhachHangId] FOREIGN KEY ([KhachHangId]) REFERENCES [KhachHangs] ([ID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_GiamSats_NhanViens_NhanVienBaoVeId] FOREIGN KEY ([NhanVienBaoVeId]) REFERENCES [NhanViens] ([ID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE TABLE [Muas] (
        [ID] int NOT NULL IDENTITY,
        [Created] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [Modified] datetime2 NOT NULL,
        [ModifiedBy] nvarchar(max) NULL,
        [KhachHangId] int NULL,
        [MatHangId] int NULL,
        CONSTRAINT [PK_Muas] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Muas_KhachHangs_KhachHangId] FOREIGN KEY ([KhachHangId]) REFERENCES [KhachHangs] ([ID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Muas_MatHangs_MatHangId] FOREIGN KEY ([MatHangId]) REFERENCES [MatHangs] ([ID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE INDEX [IX_NhanViens_GiamDocId] ON [NhanViens] ([GiamDocId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE INDEX [IX_HopDongs_DoiTacId] ON [HopDongs] ([DoiTacId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE INDEX [IX_HopDongs_NhanVienDaiDienId] ON [HopDongs] ([NhanVienDaiDienId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE INDEX [IX_ChiNhanhs_GiamDocId] ON [ChiNhanhs] ([GiamDocId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE INDEX [IX_CuaHangs_NhanVienQuanLyId] ON [CuaHangs] ([NhanVienQuanLyId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE INDEX [IX_GiamSats_KhachHangId] ON [GiamSats] ([KhachHangId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE INDEX [IX_GiamSats_NhanVienBaoVeId] ON [GiamSats] ([NhanVienBaoVeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE INDEX [IX_KhachHangs_TinhThanhId] ON [KhachHangs] ([TinhThanhId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE INDEX [IX_KinhDoanhs_CuaHangId] ON [KinhDoanhs] ([CuaHangId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE INDEX [IX_KinhDoanhs_MatHangId] ON [KinhDoanhs] ([MatHangId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE INDEX [IX_Muas_KhachHangId] ON [Muas] ([KhachHangId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE INDEX [IX_Muas_MatHangId] ON [Muas] ([MatHangId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    CREATE INDEX [IX_TinhThanhs_ChiNhanhId] ON [TinhThanhs] ([ChiNhanhId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    ALTER TABLE [HopDongs] ADD CONSTRAINT [FK_HopDongs_DoiTacs_DoiTacId] FOREIGN KEY ([DoiTacId]) REFERENCES [DoiTacs] ([ID]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    ALTER TABLE [HopDongs] ADD CONSTRAINT [FK_HopDongs_NhanViens_NhanVienDaiDienId] FOREIGN KEY ([NhanVienDaiDienId]) REFERENCES [NhanViens] ([ID]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    ALTER TABLE [NhanViens] ADD CONSTRAINT [FK_NhanViens_GiamDocs_GiamDocId] FOREIGN KEY ([GiamDocId]) REFERENCES [GiamDocs] ([ID]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219041530_complete-base')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210219041530_complete-base', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210219081113_test-change-model')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210219081113_test-change-model', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TinhThanhs]') AND [c].[name] = N'Modified');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TinhThanhs] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [TinhThanhs] ALTER COLUMN [Modified] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TinhThanhs]') AND [c].[name] = N'Created');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [TinhThanhs] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [TinhThanhs] ALTER COLUMN [Created] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[NhanViens]') AND [c].[name] = N'Modified');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [NhanViens] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [NhanViens] ALTER COLUMN [Modified] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[NhanViens]') AND [c].[name] = N'Created');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [NhanViens] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [NhanViens] ALTER COLUMN [Created] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Muas]') AND [c].[name] = N'Modified');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Muas] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Muas] ALTER COLUMN [Modified] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Muas]') AND [c].[name] = N'Created');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Muas] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Muas] ALTER COLUMN [Created] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MatHangs]') AND [c].[name] = N'Modified');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [MatHangs] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [MatHangs] ALTER COLUMN [Modified] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MatHangs]') AND [c].[name] = N'Created');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [MatHangs] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [MatHangs] ALTER COLUMN [Created] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[KinhDoanhs]') AND [c].[name] = N'Modified');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [KinhDoanhs] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [KinhDoanhs] ALTER COLUMN [Modified] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[KinhDoanhs]') AND [c].[name] = N'Created');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [KinhDoanhs] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [KinhDoanhs] ALTER COLUMN [Created] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[KhachHangs]') AND [c].[name] = N'Modified');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [KhachHangs] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [KhachHangs] ALTER COLUMN [Modified] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[KhachHangs]') AND [c].[name] = N'Created');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [KhachHangs] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [KhachHangs] ALTER COLUMN [Created] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[HopDongs]') AND [c].[name] = N'Modified');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [HopDongs] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [HopDongs] ALTER COLUMN [Modified] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[HopDongs]') AND [c].[name] = N'Created');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [HopDongs] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [HopDongs] ALTER COLUMN [Created] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[GiamSats]') AND [c].[name] = N'Modified');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [GiamSats] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [GiamSats] ALTER COLUMN [Modified] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[GiamSats]') AND [c].[name] = N'Created');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [GiamSats] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [GiamSats] ALTER COLUMN [Created] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[GiamDocs]') AND [c].[name] = N'Modified');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [GiamDocs] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [GiamDocs] ALTER COLUMN [Modified] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[GiamDocs]') AND [c].[name] = N'Created');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [GiamDocs] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [GiamDocs] ALTER COLUMN [Created] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DoiTacs]') AND [c].[name] = N'Modified');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [DoiTacs] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [DoiTacs] ALTER COLUMN [Modified] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DoiTacs]') AND [c].[name] = N'Created');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [DoiTacs] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [DoiTacs] ALTER COLUMN [Created] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CuaHangs]') AND [c].[name] = N'Modified');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [CuaHangs] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [CuaHangs] ALTER COLUMN [Modified] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CuaHangs]') AND [c].[name] = N'Created');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [CuaHangs] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [CuaHangs] ALTER COLUMN [Created] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ChiNhanhs]') AND [c].[name] = N'Modified');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [ChiNhanhs] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [ChiNhanhs] ALTER COLUMN [Modified] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ChiNhanhs]') AND [c].[name] = N'Created');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [ChiNhanhs] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [ChiNhanhs] ALTER COLUMN [Created] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210221061030_alter-model-base')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210221061030_alter-model-base', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210224074301_add-author-authen')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210224074301_add-author-authen')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
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
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210224074301_add-author-authen')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210224074301_add-author-authen')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210224074301_add-author-authen')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210224074301_add-author-authen')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210224074301_add-author-authen')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210224074301_add-author-authen')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210224074301_add-author-authen')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210224074301_add-author-authen')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210224074301_add-author-authen')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210224074301_add-author-authen')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210224074301_add-author-authen')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210224074301_add-author-authen')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210224074301_add-author-authen')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210224074301_add-author-authen', N'3.1.1');
END;

GO


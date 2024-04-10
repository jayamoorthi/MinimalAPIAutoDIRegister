BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240407070605_AlterLogiIdIsRequired', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[RoleMaster]') AND [c].[name] = N'LoginId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [RoleMaster] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [RoleMaster] DROP COLUMN [LoginId];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240407070801_RemovedLogiId', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [LoginUser] ADD [PeriodEnd] datetime2 NOT NULL DEFAULT '9999-12-31T23:59:59.9999999';
GO

ALTER TABLE [LoginUser] ADD [PeriodStart] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

ALTER TABLE [LoginUser] ADD PERIOD FOR SYSTEM_TIME ([PeriodStart], [PeriodEnd])
GO

ALTER TABLE [LoginUser] ALTER COLUMN [PeriodStart] ADD HIDDEN
GO

ALTER TABLE [LoginUser] ALTER COLUMN [PeriodEnd] ADD HIDDEN
GO

DECLARE @historyTableSchema sysname = SCHEMA_NAME()
EXEC(N'ALTER TABLE [LoginUser] SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [' + @historyTableSchema + '].[LoginUserHistory]))')

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240410053848_LoginuserHistory', N'7.0.1');
GO

COMMIT;
GO


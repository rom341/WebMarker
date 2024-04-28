BEGIN TRANSACTION;
GO

DELETE FROM AspNetRoleClaims;
GO

DELETE FROM AspNetRoles;
GO

DELETE FROM AspNetUserClaims;
GO

DELETE FROM AspNetUserLogins;
GO

DELETE FROM AspNetUserRoles;
GO

DELETE FROM AspNetUsers;
GO

DELETE FROM AspNetUserTokens;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240428184406_ClearData', N'8.0.4');
GO

COMMIT;
GO


DROP INDEX [IX_Notes_ItemId] ON [Notes];

GO

CREATE UNIQUE INDEX [IX_Notes_ItemId] ON [Notes] ([ItemId]) WHERE [Deleted]=0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190813144240_FilterIndex', N'2.2.6-servicing-10079');

GO
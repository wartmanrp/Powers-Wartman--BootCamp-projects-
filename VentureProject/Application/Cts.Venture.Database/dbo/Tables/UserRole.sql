CREATE TABLE [dbo].[UserRole] (
    [UserKey] INT NOT NULL,
    [RoleKey] INT NOT NULL,
    CONSTRAINT [PK_PersonPrivilege] PRIMARY KEY CLUSTERED ([UserKey] ASC, [RoleKey] ASC),
    CONSTRAINT [FK_UserRole_Role] FOREIGN KEY ([RoleKey]) REFERENCES [dbo].[Role] ([RoleKey]),
    CONSTRAINT [FK_UserRole_User] FOREIGN KEY ([UserKey]) REFERENCES [dbo].[User] ([UserKey])
);


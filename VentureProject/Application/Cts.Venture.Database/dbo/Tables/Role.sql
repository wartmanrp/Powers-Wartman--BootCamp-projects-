CREATE TABLE [dbo].[Role] (
    [RoleKey]  INT          IDENTITY (1, 1) NOT NULL,
    [RoleName] NVARCHAR(15) NOT NULL,
    CONSTRAINT [PK_RoleKey] PRIMARY KEY CLUSTERED ([RoleKey] ASC)
);


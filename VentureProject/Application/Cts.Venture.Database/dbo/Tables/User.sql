CREATE TABLE [dbo].[User] (
    [UserKey]     INT           IDENTITY (1, 1) NOT NULL,
    [Username]    NVARCHAR(30)  NOT NULL,
    [Password]    NVARCHAR(250) NOT NULL,
    [FirstName]   NVARCHAR(25)  NOT NULL,
    [MiddleName]  NVARCHAR(25)  NULL,
    [LastName]    NVARCHAR(35)  NOT NULL,
    [Phone]       NVARCHAR(20)  NOT NULL,
    [DateOfBirth] DATE      NULL,
    [Email]       NVARCHAR(100) NULL,
    [SupervisorUserKey] INT NULL, 
    CONSTRAINT [PK_UserKey] PRIMARY KEY CLUSTERED ([UserKey] ASC),
    CONSTRAINT [UQ_Username] UNIQUE NONCLUSTERED ([Username] ASC),
	CONSTRAINT [FK_User_Supervisor] FOREIGN KEY (SupervisorUserKey) REFERENCES dbo.[User] (UserKey) 
);


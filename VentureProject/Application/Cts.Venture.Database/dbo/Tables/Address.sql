CREATE TABLE [dbo].[Address] (
    [AddressKey] INT           IDENTITY (1, 1) NOT NULL,
    [Address1]   NVARCHAR(100) NOT NULL,
    [Address2]   NCHAR (100)   NULL,
    [City]       NVARCHAR(50)  NOT NULL,
    [StateKey]   INT           NULL,
    [ZipCode]    NVARCHAR(15)  NOT NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([AddressKey] ASC),
    CONSTRAINT [FK_Address_State] FOREIGN KEY ([StateKey]) REFERENCES [dbo].[State] ([StateKey])
);


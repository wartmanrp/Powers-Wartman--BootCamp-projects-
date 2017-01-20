CREATE TABLE [dbo].[UserAddress] (
    [UserKey]    INT NOT NULL,
    [AddressKey] INT NOT NULL,
    CONSTRAINT [PK_UserAddress] PRIMARY KEY CLUSTERED ([UserKey] ASC, [AddressKey] ASC),
    CONSTRAINT [FK_UserAddress_Address] FOREIGN KEY ([AddressKey]) REFERENCES [dbo].[Address] ([AddressKey]),
    CONSTRAINT [FK_UserAddress_User] FOREIGN KEY ([UserKey]) REFERENCES [dbo].[User] ([UserKey])
);


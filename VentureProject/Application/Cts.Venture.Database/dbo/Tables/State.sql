CREATE TABLE [dbo].[State] (
    [StateKey]   INT          IDENTITY (1, 1) NOT NULL,
    [StateName]  NVARCHAR(50) NOT NULL,
    [StateAbbrv] NVARCHAR(5)  NOT NULL,
    CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED ([StateKey] ASC)
);


CREATE TABLE [dbo].[Addresses] (
    [RegID]      INT           IDENTITY (1, 1) NOT NULL,
    [UserID]     INT           NOT NULL,
    [StreetName] NVARCHAR (50) NOT NULL,
    [Number]     SMALLINT      NOT NULL,
    [CornerName] NVARCHAR (50) NOT NULL,
    [City]       NVARCHAR (50) NOT NULL,
    [PostalCode] TINYINT       NOT NULL,
    CONSTRAINT [PK__Addresse__2C6821181C145387] PRIMARY KEY CLUSTERED ([RegID] ASC),
    CONSTRAINT [FK_Addresses_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);


CREATE TABLE [dbo].[Passwords] (
    [UserID]   INT           NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Passwords] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_Passwords] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);


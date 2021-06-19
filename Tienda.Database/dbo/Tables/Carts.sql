CREATE TABLE [dbo].[Carts] (
    [CartID]     INT           IDENTITY (1, 1) NOT NULL,
    [UserID]     INT           NOT NULL,
    [Date]       DATETIME2 (7) CONSTRAINT [DF__Carts__Date__5AA5354D] DEFAULT (getdate()) NULL,
    [GrandTotal] AS            ([dbo].[CalculateTotal]([CartID],(1))),
    [IsOpen]     BIT           CONSTRAINT [DF__Carts__IsOpen__5B995986] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED ([CartID] ASC),
    CONSTRAINT [FK_Cart_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);


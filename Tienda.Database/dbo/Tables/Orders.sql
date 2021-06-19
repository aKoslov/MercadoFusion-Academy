CREATE TABLE [dbo].[Orders] (
    [OrderID]       INT           IDENTITY (1, 1) NOT NULL,
    [UserID]        INT           NOT NULL,
    [ReceiptNumber] AS            (substring(concat([UserID],'D',right([OrderID],(1))+(1),substring(CONVERT([varchar],datepart(nanosecond,[Date])),(6),(2)),substring(CONVERT([varchar],datepart(millisecond,[Date])),(1),(2)),'C',datepart(dayofyear,[Date]),datepart(day,[Date])),(1),(12))),
    [Date]          DATETIME2 (7) CONSTRAINT [DF__Orders__Date__6522C3C0] DEFAULT (getdate()) NULL,
    [GrandTotal]    AS            ([dbo].[CalculateTotal]([OrderID],(0))),
    [Paid]          BIT           CONSTRAINT [DF__Orders__Paid__6616E7F9] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([OrderID] ASC),
    CONSTRAINT [FK_Order_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID]),
    CONSTRAINT [UQ__Orders__C08AFDABF01A0CED] UNIQUE NONCLUSTERED ([ReceiptNumber] ASC)
);


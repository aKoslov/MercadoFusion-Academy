CREATE TABLE [dbo].[Sessions] (
    [SessionID]  INT           IDENTITY (1, 1) NOT NULL,
    [UserID]     INT           NOT NULL,
    [LoginTime]  DATETIME      CONSTRAINT [DF__Sessions__LoginT__48868512] DEFAULT (getdate()) NOT NULL,
    [IsActive]   BIT           CONSTRAINT [DF__Sessions__IsActi__497AA94B] DEFAULT ((1)) NULL,
    [LogoutTime] DATETIME      NULL,
    [IP]         NVARCHAR (15) NOT NULL,
    CONSTRAINT [PK__Sessions__C9F4927003A6DA2E] PRIMARY KEY CLUSTERED ([SessionID] ASC),
    CONSTRAINT [FK_Sessions_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);


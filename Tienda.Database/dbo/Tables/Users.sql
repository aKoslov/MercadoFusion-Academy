CREATE TABLE [dbo].[Users] (
    [UserID]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50)  NOT NULL,
    [LastName]     NVARCHAR (50)  NOT NULL,
    [FullName]     AS             (([Name]+' ')+[LastName]),
    [DNI]          INT            NOT NULL,
    [PhoneNumber]  NVARCHAR (15)  NULL,
    [Username]     NVARCHAR (50)  NOT NULL,
    [Password]     NVARCHAR (300) NOT NULL,
    [CreationDate] DATETIME       CONSTRAINT [DF__Users__CreationD__40E5634A] DEFAULT (getdate()) NULL,
    [UserType]     TINYINT        CONSTRAINT [DF__Users__UserType__41D98783] DEFAULT ((1)) NOT NULL,
    [Salt]         NVARCHAR (150) NULL,
    CONSTRAINT [PK__Users__1788CCACC2CF1916] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_Users_UserType] FOREIGN KEY ([UserType]) REFERENCES [dbo].[UserTypes] ([TypeID]),
    CONSTRAINT [UQ__Users__536C85E4D2FEEFAA] UNIQUE NONCLUSTERED ([Username] ASC)
);


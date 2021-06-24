CREATE TABLE [dbo].[UserStatus] (
    [UserStatusId] TINYINT      IDENTITY (1, 1) NOT NULL,
    [Description]  VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_UserStatus] PRIMARY KEY CLUSTERED ([UserStatusId] ASC)
);


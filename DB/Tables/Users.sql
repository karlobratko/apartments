CREATE TABLE [dbo].[Users]
(
  [ID]          int           NOT NULL IDENTITY(1,1),
  [CreateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Users_CreateDate] DEFAULT GETDATE(),
  [CreatedBy]   int           NOT NULL,
  [UpdateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Users_UpdateDate] DEFAULT GETDATE(),
  [UpdatedBy]   int           NOT NULL,
  [DeleteDate]  datetime      NULL,
  [DeletedBy]   int           NULL,

  [FName]        nvarchar(50)  NOT NULL,
  [LName]        nvarchar(50)  NOT NULL,
  [Username]     nvarchar(50)  NOT NULL,
  [Email]        nvarchar(256) NOT NULL,
  [PhoneNumber]  nvarchar(20)  NOT NULL,
  [PasswordHash] nvarchar(512) NOT NULL,
  [Address]      nvarchar(200) NULL,
  [IsAdmin]      bit           NOT NULL
    CONSTRAINT [DF_Users_IsAdmin] DEFAULT 0,

  CONSTRAINT [PK_Users] PRIMARY KEY ([ID]),

  CONSTRAINT [FK_Users_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([ID]),
  CONSTRAINT [FK_Users_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[Users] ([ID]),
  CONSTRAINT [FK_Users_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[Users] ([ID])
)
GO

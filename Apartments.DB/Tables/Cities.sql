CREATE TABLE [dbo].[Cities]
(
  [Id]          int               NOT NULL IDENTITY(1,1),
  [Guid]        uniqueidentifier  NOT NULL
    CONSTRAINT [DF_Cities_Guid] DEFAULT NEWSEQUENTIALID(),
  [CreateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Cities_CreateDate] DEFAULT GETDATE(),
  [CreatedBy]   int           NOT NULL,
  [UpdateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Cities_UpdateDate] DEFAULT GETDATE(),
  [UpdatedBy]   int           NOT NULL,
  [DeleteDate]  datetime      NULL,
  [DeletedBy]   int           NULL,

  [Name]        nvarchar(100) NOT NULL,

  CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED ([Id] ASC),

  CONSTRAINT [FK_Cities_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_Cities_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_Cities_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[Users] ([Id]),
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Cities_Guid] ON [dbo].[Cities] ([Guid] ASC)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Cities_Name] ON [dbo].[Cities] ([Name] ASC)
GO
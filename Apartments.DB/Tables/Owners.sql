CREATE TABLE [dbo].[Owners]
(
  [Id]          int               NOT NULL IDENTITY(1,1),
  [Guid]        uniqueidentifier  NOT NULL
    CONSTRAINT [DF_Owners_Guid] DEFAULT NEWSEQUENTIALID(),
  [CreateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Owners_CreateDate] DEFAULT GETDATE(),
  [CreatedBy]   int           NOT NULL,
  [UpdateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Owners_UpdateDate] DEFAULT GETDATE(),
  [UpdatedBy]   int           NOT NULL,
  [DeleteDate]  datetime      NULL,
  [DeletedBy]   int           NULL,

  [Name]        nvarchar(100) NOT NULL,

  CONSTRAINT [PK_Owners] PRIMARY KEY CLUSTERED ([Id] ASC),

  CONSTRAINT [FK_Owners_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_Owners_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_Owners_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[Users] ([Id]),
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Owners_Guid] ON [dbo].[Owners] ([Guid] ASC)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Owners_Name] ON [dbo].[Owners] ([Name] ASC)
GO
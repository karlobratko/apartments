CREATE TABLE [dbo].[TagTypes]
(
  [Id]          int               NOT NULL IDENTITY(1,1),
  [Guid]        uniqueidentifier  NOT NULL
    CONSTRAINT [DF_TagTypes_Guid] DEFAULT NEWSEQUENTIALID(),
  [CreateDate]  datetime      NOT NULL
    CONSTRAINT [DF_TagTypes_CreateDate] DEFAULT GETDATE(),
  [CreatedBy]   int           NOT NULL,
  [UpdateDate]  datetime      NOT NULL
    CONSTRAINT [DF_TagTypes_UpdateDate] DEFAULT GETDATE(),
  [UpdatedBy]   int           NOT NULL,
  [DeleteDate]  datetime      NULL,
  [DeletedBy]   int           NULL,

  [Name]        nvarchar(100) NOT NULL,
  [NameEng]     nvarchar(100) NOT NULL,

  CONSTRAINT [PK_TagTypes] PRIMARY KEY CLUSTERED ([Id] ASC),

  CONSTRAINT [FK_TagTypes_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_TagTypes_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_TagTypes_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[Users] ([Id]),
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_TagTypes_Guid] ON [dbo].[TagTypes] ([Guid] ASC)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_TagTypes_Name] ON [dbo].[TagTypes] ([Name] ASC)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_TagTypes_NameEng] ON [dbo].[TagTypes] ([NameEng] ASC)
GO
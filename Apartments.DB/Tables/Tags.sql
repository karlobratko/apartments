CREATE TABLE [dbo].[Tags]
(
  [Id]          int               NOT NULL IDENTITY(1,1),
  [Guid]        uniqueidentifier  NOT NULL
    CONSTRAINT [DF_Tags_Guid] DEFAULT NEWSEQUENTIALID(),
  [CreateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Tags_CreateDate] DEFAULT GETDATE(),
  [CreatedBy]   int           NOT NULL,
  [UpdateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Tags_UpdateDate] DEFAULT GETDATE(),
  [UpdatedBy]   int           NOT NULL,
  [DeleteDate]  datetime      NULL,
  [DeletedBy]   int           NULL,

  [Name]        nvarchar(100) NOT NULL,
  [NameEng]     nvarchar(100) NOT NULL,
  [TagTypeFK]   int           NOT NULL,

  CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED ([Id] ASC),

  CONSTRAINT [FK_Tags_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_Tags_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_Tags_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[Users] ([Id]),

  CONSTRAINT [FK_Tags_TagType] FOREIGN KEY ([TagTypeFK]) REFERENCES [dbo].[TagTypes] ([Id]),
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Tags_Guid] ON [dbo].[Tags] ([Guid] ASC)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Tags_Name] ON [dbo].[Tags] ([Name] ASC)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Tags_NameEng] ON [dbo].[Tags] ([NameEng] ASC)
GO
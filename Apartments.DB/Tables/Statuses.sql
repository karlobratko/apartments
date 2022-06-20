CREATE TABLE [dbo].[Statuses]
(
  [Id]          int               NOT NULL IDENTITY(1,1),
  [Guid]        uniqueidentifier  NOT NULL
    CONSTRAINT [DF_Statuses_Guid] DEFAULT NEWSEQUENTIALID(),
  [CreateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Statuses_CreateDate] DEFAULT GETDATE(),
  [CreatedBy]   int           NOT NULL,
  [UpdateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Statuses_UpdateDate] DEFAULT GETDATE(),
  [UpdatedBy]   int           NOT NULL,
  [DeleteDate]  datetime      NULL,
  [DeletedBy]   int           NULL,

  [Name]        nvarchar(100) NOT NULL,
  [NameEng]     nvarchar(100) NOT NULL,

  CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED ([Id] ASC),

  CONSTRAINT [FK_Statuses_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_Statuses_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_Statuses_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[Users] ([Id]),
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Statuses_Guid] ON [dbo].[Statuses] ([Guid] ASC)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Statuses_Name] ON [dbo].[Statuses] ([Name] ASC, [NameEng] ASC)
GO
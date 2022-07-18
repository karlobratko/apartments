CREATE TABLE [dbo].[Pictures]
(
  [Id]          int               NOT NULL IDENTITY(1,1),
  [Guid]        uniqueidentifier  NOT NULL
    CONSTRAINT [DF_Pictures_Guid] DEFAULT NEWSEQUENTIALID(),
  [CreateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Pictures_CreateDate] DEFAULT GETDATE(),
  [CreatedBy]   int           NOT NULL,
  [UpdateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Pictures_UpdateDate] DEFAULT GETDATE(),
  [UpdatedBy]   int           NOT NULL,
  [DeleteDate]  datetime      NULL,
  [DeletedBy]   int           NULL,

  [ApartmentFK]       int             NOT NULL,
  [Title]             nvarchar(100)   NOT NULL,
  [Data]              varbinary(MAX) NOT NULL,
  [MimeType]          nvarchar(50)    NOT NULL,
  [IsRepresentative]  bit             NOT NULL
    CONSTRAINT [DF_Pictures_IsRepresentative] DEFAULT 0,

  CONSTRAINT [PK_Pictures] PRIMARY KEY CLUSTERED ([Id] ASC),

  CONSTRAINT [FK_Pictures_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_Pictures_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_Pictures_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[Users] ([Id]),

  CONSTRAINT [FK_Pictures_Apartment] FOREIGN KEY ([ApartmentFK]) REFERENCES [dbo].[Apartments] ([Id]),
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Pictures_Guid] ON [dbo].[Pictures] ([Guid] ASC)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Pictures_TitleApartmentFK] ON [dbo].[Pictures] ([Title] ASC, [ApartmentFK] ASC)
GO
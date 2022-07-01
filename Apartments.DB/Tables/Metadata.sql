CREATE TABLE [dbo].[Metadata]
(
  [Id]          int               NOT NULL IDENTITY(1,1),
  [Guid]        uniqueidentifier  NOT NULL
    CONSTRAINT [DF_Metadata_Guid] DEFAULT NEWSEQUENTIALID(),
  [CreateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Metadata_CreateDate] DEFAULT GETDATE(),
  [CreatedBy]   int           NOT NULL,
  [UpdateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Metadata_UpdateDate] DEFAULT GETDATE(),
  [UpdatedBy]   int           NOT NULL,
  [DeleteDate]  datetime      NULL,
  [DeletedBy]   int           NULL,

  [Name]             nvarchar(100) NOT NULL,
  [OIB]              nvarchar(11)  NOT NULL,
  [CityFK]           int           NOT NULL,
  [Address]          nvarchar(200) NOT NULL,
  [Telephone]        nvarchar(20)  NOT NULL,
  [Mobile]           nvarchar(20)  NOT NULL,
  [Email]            nvarchar(256) NOT NULL,

  CONSTRAINT [PK_Metadata] PRIMARY KEY CLUSTERED ([Id] ASC),

  CONSTRAINT [FK_Metadata_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_Metadata_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_Metadata_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[Users] ([Id]),

  CONSTRAINT [FK_Metadata_City] FOREIGN KEY ([CityFK]) REFERENCES [dbo].[Cities] ([Id]),
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Metadata_Guid] ON [dbo].[Metadata] ([Guid] ASC)
GO
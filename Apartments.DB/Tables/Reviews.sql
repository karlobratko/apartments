CREATE TABLE [dbo].[Reviews]
(
  [Id]          int               NOT NULL IDENTITY(1,1),
  [Guid]        uniqueidentifier  NOT NULL
    CONSTRAINT [DF_Reviews_Guid] DEFAULT NEWSEQUENTIALID(),
  [CreateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Reviews_CreateDate] DEFAULT GETDATE(),
  [CreatedBy]   int           NOT NULL,
  [UpdateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Reviews_UpdateDate] DEFAULT GETDATE(),
  [UpdatedBy]   int           NOT NULL,
  [DeleteDate]  datetime      NULL,
  [DeletedBy]   int           NULL,

  [ApartmentFK] int           NOT NULL,
  [UserFK]      int           NOT NULL,
  [Details]     nvarchar(500) NOT NULL,
  [Stars]       int           NOT NULL,

  CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED ([Id] ASC),

  CONSTRAINT [FK_Reviews_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_Reviews_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_Reviews_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[Users] ([Id]),

  CONSTRAINT [FK_Reviews_Apartment] FOREIGN KEY ([ApartmentFK])  REFERENCES [dbo].[Apartments] ([Id]),
  CONSTRAINT [FK_Reviews_User]      FOREIGN KEY ([UserFK])       REFERENCES [dbo].[Users] ([Id]),
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Reviews_Guid] ON [dbo].[Reviews] ([Guid] ASC)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Reviews_ApartmentUser] ON [dbo].[Reviews] ([ApartmentFK] ASC, [UserFK] ASC)
GO
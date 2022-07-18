CREATE TABLE [dbo].[TagsApartments]
(
  [Id]          int               NOT NULL IDENTITY(1,1),
  [Guid]        uniqueidentifier  NOT NULL
    CONSTRAINT [DF_TagsApartments_Guid] DEFAULT NEWSEQUENTIALID(),
  [CreateDate]  datetime      NOT NULL
    CONSTRAINT [DF_TagsApartments_CreateDate] DEFAULT GETDATE(),
  [CreatedBy]   int           NOT NULL,
  [UpdateDate]  datetime      NOT NULL
    CONSTRAINT [DF_TagsApartments_UpdateDate] DEFAULT GETDATE(),
  [UpdatedBy]   int           NOT NULL,
  [DeleteDate]  datetime      NULL,
  [DeletedBy]   int           NULL,

  [TagFK]       int NOT NULL,
  [ApartmentFK] int NOT NULL,

  CONSTRAINT [PK_TagsApartments] PRIMARY KEY CLUSTERED ([Id] ASC),

  CONSTRAINT [FK_TagsApartments_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_TagsApartments_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_TagsApartments_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[Users] ([Id]),

  CONSTRAINT [FK_TagsApartments_Apartment] FOREIGN KEY ([ApartmentFK])  REFERENCES [dbo].[Apartments] ([Id]),
  CONSTRAINT [FK_TagsApartments_Tag]       FOREIGN KEY ([TagFK])        REFERENCES [dbo].[Tags] ([Id]),
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_TagsApartments_Guid] ON [dbo].[TagsApartments] ([Guid] ASC)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_TagsApartments_TagApartment] ON [dbo].[TagsApartments] ([TagFK] ASC, [ApartmentFK] ASC)
GO
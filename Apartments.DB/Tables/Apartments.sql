CREATE TABLE [dbo].[Apartments]
(
  [Id]          int               NOT NULL IDENTITY(1,1),
  [Guid]        uniqueidentifier  NOT NULL
    CONSTRAINT [DF_Apartments_Guid] DEFAULT NEWSEQUENTIALID(),
  [CreateDate]  datetime          NOT NULL
    CONSTRAINT [DF_Apartments_CreateDate] DEFAULT GETDATE(),
  [CreatedBy]   int               NOT NULL,
  [UpdateDate]  datetime          NOT NULL
    CONSTRAINT [DF_Apartments_UpdateDate] DEFAULT GETDATE(),
  [UpdatedBy]   int               NOT NULL,
  [DeleteDate]  datetime          NULL,
  [DeletedBy]   int               NULL,

  [OwnerFK]       int           NOT NULL,
  [StatusFK]      int           NOT NULL,
  [Name]          nvarchar(100) NOT NULL,
  [NameEng]       nvarchar(100) NOT NULL,
  [CityFK]        int           NOT NULL,
  [Address]       nvarchar(200) NOT NULL,
  [Price]         money         NOT NULL,
  [MaxAdults]     int           NOT NULL,
  [MaxChildren]   int           NOT NULL,
  [TotalRooms]    int           NOT NULL,
  [BeachDistance] int           NOT NULL

  CONSTRAINT [PK_Apartments] PRIMARY KEY CLUSTERED ([Id] ASC),

  CONSTRAINT [FK_Apartments_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_Apartments_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_Apartments_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[Users] ([Id]),

  CONSTRAINT [FK_Apartments_Owner]  FOREIGN KEY ([OwnerFK])   REFERENCES [dbo].[Owners] ([Id]),
  CONSTRAINT [FK_Apartments_Status] FOREIGN KEY ([StatusFK])  REFERENCES [dbo].[Statuses] ([Id]),
  CONSTRAINT [FK_Apartments_City]   FOREIGN KEY ([CityFK])    REFERENCES [dbo].[Cities] ([Id]),
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Apartments_Guid] ON [dbo].[Apartments] ([Guid] ASC)
GO
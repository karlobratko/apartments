CREATE TABLE [dbo].[Reviews]
(
  [ID]          int           NOT NULL IDENTITY(1,1),
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

  CONSTRAINT [PK_Reviews] PRIMARY KEY ([ID]),

  CONSTRAINT [FK_Reviews_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([ID]),
  CONSTRAINT [FK_Reviews_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[Users] ([ID]),
  CONSTRAINT [FK_Reviews_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[Users] ([ID]),

  CONSTRAINT [FK_Reviews_Apartment]  FOREIGN KEY ([ApartmentFK])  REFERENCES [dbo].[Apartments] ([ID]),
  CONSTRAINT [FK_Reviews_User]       FOREIGN KEY ([UserFK])       REFERENCES [dbo].[Users] ([ID]),

  CONSTRAINT [CK_Reviews_Stars]      CHECK ([Stars] BETWEEN 1 AND 5),
)
GO

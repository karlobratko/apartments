CREATE TABLE [dbo].[Pictures]
(
  [ID]          int           NOT NULL IDENTITY(1,1),
  [CreateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Pictures_CreateDate] DEFAULT GETDATE(),
  [CreatedBy]   int           NOT NULL,
  [UpdateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Pictures_UpdateDate] DEFAULT GETDATE(),
  [UpdatedBy]   int           NOT NULL,
  [DeleteDate]  datetime      NULL,
  [DeletedBy]   int           NULL,

  [ApartmentFK]       int           NOT NULL,
  [Name]              nvarchar(100) NOT NULL,
  [Path]              nvarchar(500) NOT NULL,
  [IsRepresentative]  bit           NOT NULL
    CONSTRAINT [DF_Pictures_IsRepresentative] DEFAULT 0,

  CONSTRAINT [PK_Pictures] PRIMARY KEY ([ID]),

  CONSTRAINT [FK_Pictures_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([ID]),
  CONSTRAINT [FK_Pictures_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[Users] ([ID]),
  CONSTRAINT [FK_Pictures_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[Users] ([ID]),

  CONSTRAINT [FK_Pictures_Apartment] FOREIGN KEY ([ApartmentFK]) REFERENCES [dbo].[Apartments] ([ID]),
)
GO

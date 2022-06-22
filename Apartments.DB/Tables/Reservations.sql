CREATE TABLE [dbo].[Reservations]
(
  [Id]          int               NOT NULL IDENTITY(1,1),
  [Guid]        uniqueidentifier  NOT NULL
    CONSTRAINT [DF_Reservations_Guid] DEFAULT NEWSEQUENTIALID(),
  [CreateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Reservations_CreateDate] DEFAULT GETDATE(),
  [CreatedBy]   int           NOT NULL,
  [UpdateDate]  datetime      NOT NULL
    CONSTRAINT [DF_Reservations_UpdateDate] DEFAULT GETDATE(),
  [UpdatedBy]   int           NOT NULL,
  [DeleteDate]  datetime      NULL,
  [DeletedBy]   int           NULL,

  [ApartmentFK]       int           NOT NULL,
  [Details]           nvarchar(500) NULL,
  [UserFK]            int           NULL,
  [UserFName]         nvarchar(50)  NOT NULL,
  [UserLName]         nvarchar(50)  NOT NULL,
  [UserEmail]         nvarchar(256) NOT NULL,
  [UserPhoneNumber]   nvarchar(20)  NOT NULL,
  [UserAddress]       nvarchar(200) NOT NULL,

  CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED ([Id] ASC),

  CONSTRAINT [FK_Reservations_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_Reservations_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[Users] ([Id]),
  CONSTRAINT [FK_Reservations_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[Users] ([Id]),

  CONSTRAINT [FK_Reservations_Apartment] FOREIGN KEY ([ApartmentFK]) REFERENCES [dbo].[Apartments] ([Id]),
  CONSTRAINT [FK_Reservations_User]      FOREIGN KEY ([UserFK])      REFERENCES [dbo].[Users] ([Id]),
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Reservations_Guid] ON [dbo].[Reservations] ([Guid] ASC)
GO
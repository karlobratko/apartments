CREATE TABLE [dbo].[Reservations]
(
  [ID]          int           NOT NULL IDENTITY(1,1),
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
  [UserName]          nvarchar(100) NULL,
  [UserEmail]         nvarchar(256) NULL,
  [UserPhoneNumber]   nvarchar(20)  NULL,
  [UserAddress]       nvarchar(200) NULL,

  CONSTRAINT [PK_Reservations] PRIMARY KEY ([ID]),

  CONSTRAINT [FK_Reservations_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users] ([ID]),
  CONSTRAINT [FK_Reservations_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[Users] ([ID]),
  CONSTRAINT [FK_Reservations_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[Users] ([ID]),

  CONSTRAINT [FK_Reservations_Apartment]  FOREIGN KEY ([ApartmentFK]) REFERENCES [dbo].[Apartments] ([ID]),
  CONSTRAINT [FK_Reservations_User]       FOREIGN KEY ([UserFK])      REFERENCES [dbo].[Users] ([ID]),
)
GO

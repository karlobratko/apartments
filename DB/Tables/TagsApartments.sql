CREATE TABLE [dbo].[TagsApartments]
(
  [ApartmentFK] int NOT NULL,
  [TagFK]       int NOT NULL,

  CONSTRAINT [PK_TagsApartments]           PRIMARY KEY ([ApartmentFK], [TagFK]),
  CONSTRAINT [FK_TagsApartments_Apartment] FOREIGN KEY ([ApartmentFK])  REFERENCES [dbo].[Apartments] ([ID]),
  CONSTRAINT [FK_TagsApartments_Tag]       FOREIGN KEY ([TagFK])        REFERENCES [dbo].[Tags] ([ID]),
)
GO

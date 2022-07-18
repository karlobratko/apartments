CREATE PROCEDURE [dbo].[ApartmentReadByTagFK] (@TagFK AS int)
AS BEGIN
  SELECT ALL
    [Apartments].[Id],
    [Apartments].[Guid],
    [Apartments].[CreateDate],
    [Apartments].[CreatedBy],
    [Apartments].[UpdateDate],
    [Apartments].[UpdatedBy],
    [Apartments].[DeleteDate],
    [Apartments].[DeletedBy],
    [OwnerFK],
    [StatusFK],
    [Name],
    [NameEng],
    [CityFK],
    [Address],
    [Price],
    [MaxAdults],
    [MaxChildren],
    [TotalRooms],
    [BeachDistance]
  FROM [dbo].[Apartments]
    INNER JOIN [dbo].[TagsApartments]
      ON [Apartments].[Id] = [TagsApartments].[ApartmentFK]
  WHERE [Apartments].[DeleteDate] IS NULL AND 
        [TagFK] = @TagFK
RETURN 0
END
GO

CREATE PROCEDURE [dbo].[ApartmentRead] (@ID AS int = NULL)
AS BEGIN
  IF @ID IS NULL BEGIN
    SELECT ALL
      [ID],
      [CreateDate],
      [CreatedBy],
      [UpdateDate],
      [UpdatedBy],
      [DeleteDate],
      [DeletedBy],
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
    WHERE [DeleteDate] IS NULL
    ORDER BY [Name] ASC
  END
  ELSE BEGIN
    SELECT ALL
      [ID],
      [CreateDate],
      [CreatedBy],
      [UpdateDate],
      [UpdatedBy],
      [DeleteDate],
      [DeletedBy],
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
    WHERE [ID] = @ID AND [DeleteDate] IS NULL
  END
END
GO

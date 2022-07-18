CREATE PROCEDURE [dbo].[ApartmentRead] (@Method AS int,
                                        @Id     AS int = NULL)
AS BEGIN
  IF @Method = 1 BEGIN
    SELECT ALL
      [Id],
      [Guid],
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
  END
  ELSE IF @Method = 2 BEGIN
    SELECT ALL
      [Id],
      [Guid],
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
  END
  ELSE IF @Method = 3 BEGIN
    SELECT ALL
      [Id],
      [Guid],
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
    WHERE [Id] = @Id
  END
  ELSE IF @Method = 4 BEGIN
    SELECT ALL
      [Id],
      [Guid],
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
    WHERE [DeleteDate] IS NULL AND
          [Id] = @Id
  END
END
GO

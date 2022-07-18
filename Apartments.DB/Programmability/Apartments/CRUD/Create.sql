CREATE PROCEDURE [dbo].[ApartmentCreate] (@OwnerFK       AS int,
                                          @StatusFK      AS int,
                                          @Name          AS nvarchar(100),
                                          @NameEng       AS nvarchar(100),
                                          @CityFK        AS int,
                                          @Address       AS nvarchar(200),
                                          @Price         AS money,
                                          @MaxAdults     AS int,
                                          @MaxChildren   AS int,
                                          @TotalRooms    AS int,
                                          @BeachDistance AS int,
                                          @CreatedBy     AS int = 1)
AS BEGIN
  INSERT INTO [dbo].[Apartments]
  (
    [CreatedBy],
    [UpdatedBy],
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
  )
  VALUES
  (
    @CreatedBy,
    @CreatedBy,
    @OwnerFK,
    @StatusFK,
    @Name,
    @NameEng,
    @CityFK,
    @Address,
    @Price,
    @MaxAdults,
    @MaxChildren,
    @TotalRooms,
    @BeachDistance
  )

  DECLARE @Id AS int = SCOPE_IDENTITY()
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

  RETURN 1
END
GO

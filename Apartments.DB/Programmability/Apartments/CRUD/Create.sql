CREATE PROCEDURE [dbo].[ApartmentCreate] (@OwnerFK AS int,
                                          @StatusFK AS int,
                                          @Name AS nvarchar(100),
                                          @NameEng AS nvarchar(100),
                                          @CityFK AS int,
                                          @Address AS nvarchar(200),
                                          @Price AS money,
                                          @MaxAdults AS int,
                                          @MaxChildren AS int,
                                          @TotalRooms AS int,
                                          @BeachDistance AS int,
                                          @CreatedBy AS int)
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

  RETURN SCOPE_IDENTITY()
END
GO

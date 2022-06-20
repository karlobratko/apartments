CREATE PROCEDURE [dbo].[ApartmentUpdate] (@ID AS int,
                                          @OwnerFK AS int,
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
                                          @UpdateBy AS int)
AS BEGIN
  UPDATE [dbo].[Apartments]
  SET
    [UpdatedBy]     = @UpdateBy,
    [UpdateDate]    = GETDATE(),
    [OwnerFK]       = @OwnerFK,
    [StatusFK]      = @StatusFK,
    [Name]          = @Name,
    [NameEng]       = @NameEng,
    [CityFK]        = @CityFK,
    [Address]       = @Address,
    [Price]         = @Price,
    [MaxAdults]     = @MaxAdults,
    [MaxChildren]   = @MaxChildren,
    [TotalRooms]    = @TotalRooms,
    [BeachDistance] = @BeachDistance
  WHERE [ID] = @ID AND [DeleteDate] IS NULL

  RETURN @@ROWCOUNT
END
GO

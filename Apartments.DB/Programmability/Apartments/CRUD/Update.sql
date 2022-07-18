CREATE PROCEDURE [dbo].[ApartmentUpdate] (@Guid          AS uniqueidentifier,
                                          @OwnerFK       AS int,
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
                                          @UpdatedBy     AS int = 1)
AS BEGIN
  DECLARE @Id         AS int
  DECLARE @DeleteDate AS datetime
  SELECT ALL TOP 1
    @Id         = [Id],
    @DeleteDate = [DeleteDate]
  FROM [dbo].[Apartments]
  WHERE [Guid] = @Guid

  IF @Id IS NULL BEGIN
    RETURN 2
  END
  ELSE IF @Id IS NOT NULL AND
          @DeleteDate IS NOT NULL BEGIN
    RETURN 3
  END

  UPDATE [dbo].[Apartments]
  SET
    [UpdatedBy]     = @UpdatedBy,
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
  WHERE [Guid] = @Guid

  IF @@ROWCOUNT = 1 BEGIN
    RETURN 1
  END
  ELSE BEGIN
    RETURN -1
  END
END
GO

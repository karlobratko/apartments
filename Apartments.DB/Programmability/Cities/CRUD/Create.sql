CREATE PROCEDURE [dbo].[CityCreate] (@Name AS nvarchar(100),
                                     @CreatedBy AS int)
AS BEGIN
  DECLARE @IsUnique AS int = (
    SELECT ALL
      COUNT(*)
    FROM [dbo].[Cities]
    WHERE [DeleteDate] IS NULL AND
          [Name] = @Name
  )
  IF @IsUnique > 0 BEGIN
    RETURN 0
  END

  INSERT INTO [dbo].[Cities]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name]
  )
  VALUES
  (
    @CreatedBy,
    @CreatedBy,
    @Name
  )

  RETURN SCOPE_IDENTITY()
END
GO

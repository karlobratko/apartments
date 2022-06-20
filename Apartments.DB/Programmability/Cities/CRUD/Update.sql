CREATE PROCEDURE [dbo].[CityUpdate] (@ID AS int,
                                     @Name AS nvarchar(100),
                                     @UpdatedBy AS int)
AS BEGIN
  DECLARE @IsUnique AS int = (
    SELECT ALL 
      COUNT(*) 
    FROM [dbo].[Cities] 
    WHERE [ID] != @ID AND
          [DeleteDate] IS NULL AND
          [Name] = @Name
  )
  IF @IsUnique > 0 BEGIN
    RETURN 0
  END

  UPDATE [dbo].[Cities]
  SET
    [UpdatedBy]     = @UpdatedBy,
    [UpdateDate]    = GETDATE(),
    [Name]          = @Name
  WHERE [ID] = @ID AND [DeleteDate] IS NULL

  RETURN @@ROWCOUNT
END
GO

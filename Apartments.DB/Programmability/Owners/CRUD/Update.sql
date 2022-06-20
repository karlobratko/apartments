CREATE PROCEDURE [dbo].[OwnerUpdate] (@ID AS int,
                                      @Name AS nvarchar(100),
                                      @UpdatedBy AS int)
AS BEGIN
  DECLARE @IsUnique AS int = (
    SELECT ALL 
      COUNT(*) 
    FROM [dbo].[Owners] 
    WHERE [ID] != @ID AND
          [DeleteDate] IS NULL AND
          [Name] = @Name
  )
  IF @IsUnique > 0 BEGIN
    RETURN 0
  END

  UPDATE [dbo].[Owners]
  SET
    [UpdatedBy]     = @UpdatedBy,
    [UpdateDate]    = GETDATE(),
    [Name]          = @Name
  WHERE [ID] = @ID AND [DeleteDate] IS NULL

  RETURN @@ROWCOUNT
END
GO
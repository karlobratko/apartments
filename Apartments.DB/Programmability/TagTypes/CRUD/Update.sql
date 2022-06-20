CREATE PROCEDURE [dbo].[TagTypeUpdate] (@ID AS int,
                                        @Name AS nvarchar(100),
                                        @NameEng AS nvarchar(100),
                                        @UpdatedBy AS int)
AS BEGIN
  DECLARE @IsUnique AS int = (
    SELECT ALL 
      COUNT(*) 
    FROM [dbo].[TagTypes] 
    WHERE [ID] != @ID AND
          [DeleteDate] IS NULL AND
          (
            [Name] = @Name OR 
            [NameEng] = @NameEng
          )
  )
  IF @IsUnique > 0 BEGIN
    RETURN 0
  END

  UPDATE [dbo].[TagTypes]
  SET
    [UpdatedBy]     = @UpdatedBy,
    [UpdateDate]    = GETDATE(),
    [Name]          = @Name,
    [NameEng]       = @NameEng
  WHERE [ID] = @ID AND [DeleteDate] IS NULL

  RETURN @@ROWCOUNT
END
GO

CREATE PROCEDURE [dbo].[TagUpdate] (@ID AS int,
                                    @Name AS nvarchar(100),
                                    @NameEng AS nvarchar(100),
                                    @TagTypeFK AS int,
                                    @UpdatedBy AS int)
AS BEGIN
  DECLARE @IsUnique AS int = (
    SELECT ALL 
      COUNT(*) 
    FROM [dbo].[Tags]
    WHERE [ID] != @ID AND
          [DeleteDate] IS NULL AND
          [TagTypeFK] = @TagTypeFK AND
          (
            [Name] = @Name OR 
            [NameEng] = @NameEng
          )
  )
  IF @IsUnique > 0 BEGIN
    RETURN 0
  END

  UPDATE [dbo].[Tags]
  SET
    [UpdatedBy]     = @UpdatedBy,
    [UpdateDate]    = GETDATE(),
    [Name]          = @Name,
    [NameEng]       = @NameEng,
    [TagTypeFK]     = @TagTypeFK
  WHERE [ID] = @ID AND [DeleteDate] IS NULL

  RETURN @@ROWCOUNT
END
GO

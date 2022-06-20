CREATE PROCEDURE [dbo].[TagCreate] (@Name AS nvarchar(100),
                                    @NameEng AS nvarchar(100),
                                    @TagTypeFK AS int,
                                    @CreatedBy AS int)
AS BEGIN
  DECLARE @IsUnique AS int = (
    SELECT ALL 
      COUNT(*) 
    FROM [dbo].[Tags] 
    WHERE [DeleteDate] IS NULL AND
          [TagTypeFK] = @TagTypeFK AND 
          (
            [Name] = @Name OR 
            [NameEng] = @NameEng
          )
  )
  IF @IsUnique > 0 BEGIN
    RETURN 0
  END

  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    @CreatedBy,
    @CreatedBy,
    @Name,
    @NameEng,
    @TagTypeFK
  )

  RETURN SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE [dbo].[TagTypeCreate] (@Name AS nvarchar(100),
                                        @NameEng AS nvarchar(100),
                                        @CreatedBy AS int)
AS BEGIN
  DECLARE @IsUnique AS int = (
    SELECT ALL 
      COUNT(*) 
    FROM [dbo].[TagTypes] 
    WHERE [DeleteDate] IS NULL AND
          (
            [Name] = @Name OR 
            [NameEng] = @NameEng
          )
  )
  IF @IsUnique > 0 BEGIN
    RETURN 0
  END

  INSERT INTO [dbo].[TagTypes]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng]
  )
  VALUES
  (
    @CreatedBy,
    @CreatedBy,
    @Name,
    @NameEng
  )

  RETURN SCOPE_IDENTITY()
END
GO

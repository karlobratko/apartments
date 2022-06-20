CREATE PROCEDURE [dbo].[PictureCreate] (@ApartmentFK AS int,
                                        @Name AS nvarchar(100),
                                        @Path AS nvarchar(500),
                                        @IsRepresentative AS bit,
                                        @CreatedBy AS int)
AS BEGIN
  IF @IsRepresentative = 0 BEGIN
    DECLARE @PicturesCount AS int = (
      SELECT ALL
        COUNT(*)
      FROM [dbo].[Pictures]
      WHERE [ApartmentFK] = @ApartmentFK AND 
            [DeleteDate] IS NULL
    )
    IF @PicturesCount = 0 BEGIN
      SET @IsRepresentative = 1
    END
  END
  ELSE BEGIN
    UPDATE [dbo].[Pictures]
    SET 
      [UpdatedBy]         = @CreatedBy,
      [UpdateDate]        = GETDATE(),
      [IsRepresentative]  = 0
    WHERE [ApartmentFK] = @ApartmentFK AND [DeleteDate] IS NULL
  END

  INSERT INTO [dbo].[Pictures]
  (
    [CreatedBy],
    [UpdatedBy],
    [ApartmentFK],
    [Name],
    [Path],
    [IsRepresentative]
  )
  VALUES
  (
    @CreatedBy,
    @CreatedBy,
    @ApartmentFK,
    @Name,
    @Path,
    @IsRepresentative
  )

  RETURN SCOPE_IDENTITY()
END
GO

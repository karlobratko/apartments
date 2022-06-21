CREATE PROCEDURE [dbo].[PictureUpdate] (@Guid             AS uniqueidentifier,
                                        @ApartmentFK      AS int,
                                        @Title            AS nvarchar(100),
                                        @Path             AS nvarchar(500),
                                        @IsRepresentative AS bit,
                                        @UpdatedBy        AS int = 1)
AS BEGIN
  DECLARE @Id AS int
  DECLARE @DeleteDate AS datetime
  SELECT ALL TOP 1
    @Id         = [Id],
    @DeleteDate = [DeleteDate]
  FROM [dbo].[Pictures]
  WHERE [Guid] = @Guid

  IF @Id IS NULL BEGIN
    RETURN 2
  END
  ELSE IF @Id IS NOT NULL AND
          @DeleteDate IS NOT NULL BEGIN
    RETURN 3
  END

  SET @Id         = NULL
  SET @DeleteDate = NULL

  SELECT ALL TOP 1
    @Id         = [Id],
    @DeleteDate = [DeleteDate]
  FROM [dbo].[Pictures]
  WHERE [Title] = @Title

  DECLARE @PicturesCount AS int

  IF @Id IS NOT NULL AND
     @DeleteDate IS NULL BEGIN
    SET @PicturesCount = (
      SELECT ALL
        COUNT(*)
      FROM [dbo].[Pictures]
      WHERE [ApartmentFK] = @ApartmentFK
    )

    IF @PicturesCount <= 1 BEGIN
      SET @IsRepresentative = 1
    END
    ELSE BEGIN
      IF @IsRepresentative = 1 BEGIN
        UPDATE [dbo].[Pictures]
        SET
          [UpdateDate]       = GETDATE(),
          [UpdatedBy]        = @UpdatedBy,
          [IsRepresentative] = 0
        WHERE [ApartmentFK] = @ApartmentFK
      END
    END

    UPDATE [dbo].[Pictures]
    SET
      [UpdatedBy]        = @UpdatedBy,
      [UpdateDate]       = GETDATE(),
      [ApartmentFK]      = @ApartmentFK,
      [Path]             = @Path,
      [IsRepresentative] = @IsRepresentative
    WHERE [Guid] = @Guid

    RETURN 4
  END
  ELSE IF @Id IS NOT NULL AND
          @DeleteDate IS NOT NULL BEGIN
    RETURN 3
  END

  SET @PicturesCount = (
    SELECT ALL
      COUNT(*)
    FROM [dbo].[Pictures]
    WHERE [ApartmentFK] = @ApartmentFK
  )

  IF @PicturesCount <= 1 BEGIN
    SET @IsRepresentative = 1
  END
  ELSE BEGIN
    IF @IsRepresentative = 1 BEGIN
      UPDATE [dbo].[Pictures]
      SET
        [UpdateDate]       = GETDATE(),
        [UpdatedBy]        = @UpdatedBy,
        [IsRepresentative] = 0
      WHERE [ApartmentFK] = @ApartmentFK
    END
  END

  UPDATE [dbo].[Pictures]
  SET
    [UpdatedBy]        = @UpdatedBy,
    [UpdateDate]       = GETDATE(),
    [ApartmentFK]      = @ApartmentFK,
    [Title]            = @Title,
    [Path]             = @Path,
    [IsRepresentative] = @IsRepresentative
  WHERE [Guid] = @Guid

  IF @@ROWCOUNT = 1 BEGIN
    RETURN 1
  END
  ELSE BEGIN
    RETURN -1
  END
END
GO

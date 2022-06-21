CREATE PROCEDURE [dbo].[PictureCreate] (@ApartmentFK      AS int,
                                        @Title            AS nvarchar(100),
                                        @Path             AS nvarchar(500),
                                        @IsRepresentative AS bit,
                                        @CreatedBy        AS int = 1)
AS BEGIN
  DECLARE @PicturesCount AS int
  DECLARE @Guid          AS uniqueidentifier
  DECLARE @DeleteDate    AS datetime
  SELECT ALL TOP 1
    @Guid       = [Guid],
    @DeleteDate = [DeleteDate]
  FROM [dbo].[Pictures]
  WHERE [Title] = @Title

  IF @Guid IS NULL BEGIN
    SET @PicturesCount = (
      SELECT ALL
        COUNT(*)
      FROM [dbo].[Pictures]
      WHERE [ApartmentFK] = @ApartmentFK AND
            [DeleteDate] IS NULL
    )

    IF @PicturesCount = 0 BEGIN
      SET @IsRepresentative = 1
    END
    ELSE BEGIN
      IF @IsRepresentative = 1 BEGIN
        UPDATE [dbo].[Pictures]
        SET
          [UpdateDate]       = GETDATE(),
          [UpdatedBy]        = @CreatedBy,
          [IsRepresentative] = 0
        WHERE [ApartmentFK] = @ApartmentFK
      END
    END

    INSERT INTO [dbo].[Pictures]
    (
      [CreatedBy],
      [UpdatedBy],
      [ApartmentFK],
      [Title],
      [Path],
      [IsRepresentative]
    )
    VALUES
    (
      @CreatedBy,
      @CreatedBy,
      @ApartmentFK,
      @Title,
      @Path,
      @IsRepresentative
    )

    DECLARE @Id AS int = SCOPE_IDENTITY()
    SELECT ALL
      [Id],
      [Guid],
      [CreateDate],
      [CreatedBy],
      [UpdateDate],
      [UpdatedBy],
      [DeleteDate],
      [DeletedBy],
      [ApartmentFK],
      [Title],
      [Path],
      [IsRepresentative]
    FROM [dbo].[Pictures]
    WHERE [Id] = @Id

    RETURN 1
  END
  ELSE IF @Guid       IS NOT NULL AND 
          @DeleteDate IS NOT NULL BEGIN
    SET @PicturesCount = (
      SELECT ALL
        COUNT(*)
      FROM [dbo].[Pictures]
      WHERE [ApartmentFK] = @ApartmentFK AND
            [DeleteDate] IS NULL
    )

    IF @PicturesCount = 0 BEGIN
      SET @IsRepresentative = 1
    END
    ELSE BEGIN
      IF @IsRepresentative = 1 BEGIN
        UPDATE [dbo].[Pictures]
        SET
          [UpdateDate]       = GETDATE(),
          [UpdatedBy]        = @CreatedBy,
          [IsRepresentative] = 0
        WHERE [ApartmentFK] = @ApartmentFK
      END
    END

    UPDATE [dbo].[Pictures]
    SET
      [DeleteDate]       = NULL,
      [DeletedBy]        = NULL,
      [UpdateDate]       = GETDATE(),
      [UpdatedBy]        = @CreatedBy,
      [ApartmentFK]      = @ApartmentFK,
      [Path]             = @Path,
      [IsRepresentative] = @IsRepresentative
    WHERE [Guid] = @Guid

    SELECT ALL
      [Id],
      [Guid],
      [CreateDate],
      [CreatedBy],
      [UpdateDate],
      [UpdatedBy],
      [DeleteDate],
      [DeletedBy],
      [ApartmentFK],
      [Title],
      [Path],
      [IsRepresentative]
    FROM [dbo].[Pictures]
    WHERE [Guid] = @Guid

    RETURN 3
  END
  ELSE IF @Guid       IS NOT NULL AND
          @DeleteDate IS NULL BEGIN
    SET @PicturesCount = (
      SELECT ALL
        COUNT(*)
      FROM [dbo].[Pictures]
      WHERE [ApartmentFK] = @ApartmentFK AND
            [DeleteDate] IS NULL
    )

    IF @PicturesCount = 0 BEGIN
      SET @IsRepresentative = 1
    END
    ELSE BEGIN
      IF @IsRepresentative = 1 BEGIN
        UPDATE [dbo].[Pictures]
        SET
          [UpdateDate]       = GETDATE(),
          [UpdatedBy]        = @CreatedBy,
          [IsRepresentative] = 0
        WHERE [ApartmentFK] = @ApartmentFK
      END
    END

    UPDATE [dbo].[Pictures]
    SET
      [UpdateDate]       = GETDATE(),
      [UpdatedBy]        = @CreatedBy,
      [ApartmentFK]      = @ApartmentFK,
      [Path]             = @Path,
      [IsRepresentative] = @IsRepresentative
    WHERE [Guid] = @Guid

    SELECT ALL
      [Id],
      [Guid],
      [CreateDate],
      [CreatedBy],
      [UpdateDate],
      [UpdatedBy],
      [DeleteDate],
      [DeletedBy],
      [ApartmentFK],
      [Title],
      [Path],
      [IsRepresentative]
    FROM [dbo].[Pictures]
    WHERE [Guid] = @Guid

    RETURN 2
  END
  ELSE BEGIN
    RETURN -1
  END
END
GO

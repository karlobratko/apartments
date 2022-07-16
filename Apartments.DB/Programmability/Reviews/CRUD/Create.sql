CREATE PROCEDURE [dbo].[ReviewCreate] (@ApartmentFK AS int,
                                       @UserFK      AS int,
                                       @Details     AS nvarchar(500),
                                       @Stars       AS int,
                                       @CreatedBy   AS int = 1)
AS BEGIN
  DECLARE @Guid       AS uniqueidentifier
  DECLARE @DeleteDate AS datetime
  SELECT ALL TOP 1
    @Guid       = [Guid],
    @DeleteDate = [DeleteDate]
  FROM [dbo].[Reviews]
  WHERE [ApartmentFK] = @ApartmentFK AND
        [UserFK]      = @UserFK

  IF @Guid IS NULL BEGIN
    INSERT INTO [dbo].[Reviews]
    (
      [CreatedBy],
      [UpdatedBy],
      [ApartmentFK],
      [UserFK],
      [Details],
      [Stars]
    )
    VALUES
    (
      @CreatedBy,
      @CreatedBy,
      @ApartmentFK,
      @UserFK,
      @Details,
      @Stars
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
      [UserFK],
      [Details],
      [Stars]
    FROM [dbo].[Reviews]
    WHERE [Id] = @Id

    RETURN 1
  END
  ELSE IF @Guid       IS NOT NULL AND 
          @DeleteDate IS NOT NULL BEGIN
    UPDATE [dbo].[Reviews]
    SET
      [DeleteDate]  = NULL,
      [DeletedBy]   = NULL,
      [UpdateDate]  = GETDATE(),
      [UpdatedBy]   = @CreatedBy,
      [Details]     = @Details,
      [Stars]       = @Stars
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
      [UserFK],
      [Details],
      [Stars]
    FROM [dbo].[Reviews]
    WHERE [Guid] = @Guid

    RETURN 3
  END
  ELSE IF @Guid       IS NOT NULL AND 
          @DeleteDate IS NULL BEGIN
    UPDATE [dbo].[Reviews]
    SET
      [UpdateDate] = GETDATE(),
      [UpdatedBy]  = @CreatedBy,
      [Details]    = @Details,
      [Stars]      = @Stars
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
      [UserFK],
      [Details],
      [Stars]
    FROM [dbo].[Reviews]
    WHERE [Guid] = @Guid

    RETURN 2
  END
  ELSE BEGIN
    RETURN -1
  END
END
GO

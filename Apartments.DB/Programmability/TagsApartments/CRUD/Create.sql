CREATE PROCEDURE [dbo].[TagApartmentCreate] (@TagFK       AS int,
                                             @ApartmentFK AS int,
                                             @CreatedBy   AS int = 1)
AS BEGIN
  DECLARE @Guid       AS uniqueidentifier
  DECLARE @DeleteDate AS datetime
  SELECT ALL TOP 1
    @Guid       = [Guid],
    @DeleteDate = [DeleteDate]
  FROM [dbo].[TagsApartments]
  WHERE [ApartmentFK] = @ApartmentFK AND
        [TagFK]      = @TagFK

  IF @Guid IS NULL BEGIN
    INSERT INTO [dbo].[TagsApartments]
    (
      [CreatedBy],
      [UpdatedBy],
      [ApartmentFK],
      [TagFK]
    )
    VALUES
    (
      @CreatedBy,
      @CreatedBy,
      @ApartmentFK,
      @TagFK
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
      [TagFK],
      [ApartmentFK]
    FROM [dbo].[TagsApartments]
    WHERE [Id] = @Id

    RETURN 1
  END
  ELSE IF @Guid       IS NOT NULL AND 
          @DeleteDate IS NOT NULL BEGIN
    UPDATE [dbo].[TagsApartments]
    SET
      [DeleteDate]  = NULL,
      [DeletedBy]   = NULL,
      [UpdateDate]  = GETDATE(),
      [UpdatedBy]   = @CreatedBy
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
      [TagFK],
      [ApartmentFK]
    FROM [dbo].[TagsApartments]
    WHERE [Guid] = @Guid

    RETURN 3
  END
  ELSE IF @Guid       IS NOT NULL AND 
          @DeleteDate IS NULL BEGIN
    UPDATE [dbo].[TagsApartments]
    SET
      [UpdateDate] = GETDATE(),
      [UpdatedBy]  = @CreatedBy
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
      [TagFK],
      [ApartmentFK]
    FROM [dbo].[TagsApartments]
    WHERE [Guid] = @Guid

    RETURN 2
  END
  ELSE BEGIN
    RETURN -1
  END
END
GO

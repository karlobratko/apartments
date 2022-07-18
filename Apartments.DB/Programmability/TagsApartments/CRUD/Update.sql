CREATE PROCEDURE [dbo].[TagApartmentUpdate] (@Guid        AS uniqueidentifier,
                                             @TagFK       AS int,
                                             @ApartmentFK AS int,
                                             @UpdatedBy   AS int = 1)
AS BEGIN
  DECLARE @Id         AS int
  DECLARE @DeleteDate AS datetime
  SELECT ALL TOP 1
    @Id         = [Id],
    @DeleteDate = [DeleteDate]
  FROM [dbo].[TagsApartments]
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
  FROM [dbo].[TagsApartments]
  WHERE [ApartmentFK] = @ApartmentFK AND
        [TagFK] = @TagFK AND
        [Guid] <> @Guid

  IF @Id IS NOT NULL AND
     @DeleteDate IS NULL BEGIN
    RETURN 4
  END
  ELSE IF @Id IS NOT NULL AND
          @DeleteDate IS NOT NULL BEGIN
    RETURN 3
  END

  UPDATE [dbo].[TagsApartments]
  SET
    [UpdatedBy]   = @UpdatedBy,
    [UpdateDate]  = GETDATE(),
    [ApartmentFK] = @ApartmentFK,
    [TagFK]       = @TagFK
  WHERE [Guid] = @Guid

  IF @@ROWCOUNT = 1 BEGIN
    RETURN 1
  END
  ELSE BEGIN
    RETURN -1
  END
END
GO

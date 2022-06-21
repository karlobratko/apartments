CREATE PROCEDURE [dbo].[StatusCreate] (@Name      AS nvarchar(100),
                                       @NameEng   AS nvarchar(100),
                                       @CreatedBy AS int = 1)
AS BEGIN
  DECLARE @Guid       AS uniqueidentifier
  DECLARE @DeleteDate AS datetime
  SELECT ALL TOP 1
    @Guid       = [Guid],
    @DeleteDate = [DeleteDate]
  FROM [dbo].[Statuses]
  WHERE [Name]    = @Name OR
        [NameEng] = @NameEng

  IF @Guid IS NULL BEGIN
    INSERT INTO [dbo].[Statuses]
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
      [Name],
      [NameEng]
    FROM [dbo].[Statuses]
    WHERE [Id] = @Id

    RETURN 1
  END
  ELSE IF @Guid       IS NOT NULL AND 
          @DeleteDate IS NOT NULL BEGIN
    SET @Guid = NULL
    SET @Guid = (
      SELECT ALL TOP 1
        [Guid]
      FROM [dbo].[Statuses]
      WHERE [Name]    = @Name AND
            [NameEng] = @NameEng
    )
    IF @Guid IS NOT NULL BEGIN
      UPDATE [dbo].[Statuses]
      SET
        [DeleteDate] = NULL,
        [DeletedBy]  = NULL,
        [UpdateDate] = GETDATE(),
        [UpdatedBy]  = @CreatedBy,
        [Name]       = @Name,
        [NameEng]    = @NameEng
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
        [Name],
        [NameEng]
      FROM [dbo].[Statuses]
      WHERE [Guid] = @Guid

      RETURN 3
    END
    ELSE BEGIN
      RETURN 2
    END
  END
  ELSE IF @Guid       IS NOT NULL AND 
          @DeleteDate IS NULL BEGIN
    UPDATE [dbo].[Statuses]
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
      [Name],
      [NameEng]
    FROM [dbo].[Statuses]
    WHERE [Guid] = @Guid

    RETURN 2
  END
  ELSE BEGIN
    RETURN -1
  END
END
GO

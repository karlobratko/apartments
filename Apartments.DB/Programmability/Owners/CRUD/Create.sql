CREATE PROCEDURE [dbo].[OwnerCreate] (@Name      AS nvarchar(100),
                                      @CreatedBy AS int = 1)
AS BEGIN
  DECLARE @Guid       AS uniqueidentifier
  DECLARE @DeleteDate AS datetime
  SELECT ALL TOP 1
    @Guid       = [Guid],
    @DeleteDate = [DeleteDate]
  FROM [dbo].[Owners]
  WHERE [Name] = @Name

  IF @Guid IS NULL BEGIN
    INSERT INTO [dbo].[Owners]
    (
      [CreatedBy],
      [UpdatedBy],
      [Name]
    )
    VALUES
    (
      @CreatedBy,
      @CreatedBy,
      @Name
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
      [Name]
    FROM [dbo].[Owners]
    WHERE [Id] = @Id

    RETURN 1
  END
  ELSE IF @Guid       IS NOT NULL AND 
          @DeleteDate IS NOT NULL BEGIN
    UPDATE [dbo].[Owners]
    SET
      [DeleteDate] = NULL,
      [DeletedBy]  = NULL,
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
      [Name]
    FROM [dbo].[Owners]
    WHERE [Guid] = @Guid

    RETURN 3
  END
  ELSE IF @Guid       IS NOT NULL AND 
          @DeleteDate IS NULL BEGIN
    UPDATE [dbo].[Owners]
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
      [Name]
    FROM [dbo].[Owners]
    WHERE [Guid] = @Guid

    RETURN 2
  END
  ELSE BEGIN
    RETURN -1
  END
END
GO

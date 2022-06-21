CREATE PROCEDURE [dbo].[TagTypeUpdate] (@Guid      AS uniqueidentifier,
                                        @Name      AS nvarchar(100),
                                        @NameEng   AS nvarchar(100),
                                        @UpdatedBy AS int = 1)
AS BEGIN
  DECLARE @Id         AS int
  DECLARE @DeleteDate AS datetime
  SELECT ALL TOP 1
    @Id         = [Id],
    @DeleteDate = [DeleteDate]
  FROM [dbo].[TagTypes]
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
  FROM [dbo].[TagTypes]
  WHERE ([Name]    = @Name OR
         [NameEng] = @NameEng) AND
        [Guid] <> @Guid

  IF @Id IS NOT NULL AND
     @DeleteDate IS NULL BEGIN
    RETURN 4
  END
  ELSE IF @Id IS NOT NULL AND
          @DeleteDate IS NOT NULL BEGIN
    RETURN 3
  END

  UPDATE [dbo].[TagTypes]
  SET
    [UpdatedBy]     = @UpdatedBy,
    [UpdateDate]    = GETDATE(),
    [Name]          = @Name,
    [NameEng]       = @NameEng
  WHERE [Guid] = @Guid

  IF @@ROWCOUNT = 1 BEGIN
    RETURN 1
  END
  ELSE BEGIN
    RETURN -1
  END
END
GO

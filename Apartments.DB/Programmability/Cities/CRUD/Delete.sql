CREATE PROCEDURE [dbo].[CityDelete] (@Guid      AS uniqueidentifier,
                                     @DeletedBy AS int = 1)
AS BEGIN
  DECLARE @Id AS int
  DECLARE @DeleteDate AS datetime
  SELECT ALL TOP 1
    @Id         = [Id],
    @DeleteDate = [DeleteDate]
  FROM [dbo].[Cities]
  WHERE [Guid] = @Guid

  IF @Id IS NULL BEGIN
    RETURN 2
  END
  ELSE IF @Id IS NOT NULL AND
          @DeleteDate IS NOT NULL BEGIN
    RETURN 3
  END

  UPDATE [dbo].[Cities]
  SET
    [DeletedBy]  = @DeletedBy,
    [DeleteDate] = GETDATE()
  WHERE [Guid] = @Guid

  IF @@ROWCOUNT = 1 BEGIN
    RETURN 1
  END
  ELSE BEGIN
    RETURN -1
  END
END
GO

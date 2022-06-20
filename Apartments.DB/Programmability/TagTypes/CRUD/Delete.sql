CREATE PROCEDURE [dbo].[TagTypeDelete] (@ID AS int,
                                        @DeletedBy AS int)
AS BEGIN
  UPDATE [dbo].[TagTypes]
  SET
    [DeletedBy]   = @DeletedBy,
    [DeleteDate]  = GETDATE()
  WHERE [ID] = @ID AND [DeleteDate] IS NULL

  RETURN @@ROWCOUNT
END
GO

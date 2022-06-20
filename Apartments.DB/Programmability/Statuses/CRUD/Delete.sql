CREATE PROCEDURE [dbo].[StatusDelete] (@ID AS int,
                                       @DeletedBy AS int)
AS BEGIN
  UPDATE [dbo].[Statuses]
  SET
    [DeletedBy]   = @DeletedBy,
    [DeleteDate]  = GETDATE()
  WHERE [ID] = @ID AND [DeleteDate] IS NULL

  RETURN @@ROWCOUNT
END
GO

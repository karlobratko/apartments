CREATE PROCEDURE [dbo].[OwnerDelete] (@ID AS int,
                                      @DeletedBy AS int)
AS BEGIN
  UPDATE [dbo].[Owners]
  SET
    [DeletedBy]   = @DeletedBy,
    [DeleteDate]  = GETDATE()
  WHERE [ID] = @ID AND [DeleteDate] IS NULL

  RETURN @@ROWCOUNT
END
GO

CREATE PROCEDURE [dbo].[TagDelete] (@ID AS int,
                                    @DeletedBy AS int)
AS BEGIN
  UPDATE [dbo].[Tags]
  SET
    [DeletedBy]   = @DeletedBy,
    [DeleteDate]  = GETDATE()
  WHERE [ID] = @ID AND [DeleteDate] IS NULL

  RETURN @@ROWCOUNT
END
GO

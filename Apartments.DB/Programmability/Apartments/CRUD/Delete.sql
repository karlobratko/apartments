CREATE PROCEDURE [dbo].[ApartmentDelete] (@ID AS int,
                                          @DeletedBy AS int)
AS BEGIN
  UPDATE [dbo].[Apartments]
  SET
    [DeletedBy]   = @DeletedBy,
    [DeleteDate]  = GETDATE()
  WHERE [ID] = @ID AND [DeleteDate] IS NULL

  RETURN @@ROWCOUNT
END
GO

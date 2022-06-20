CREATE PROCEDURE [dbo].[CityDelete] (@ID AS int,
                                     @DeletedBy AS int)
AS BEGIN
  UPDATE [dbo].[Cities]
  SET
    [DeletedBy]   = @DeletedBy,
    [DeleteDate]  = GETDATE()
  WHERE [ID] = @ID AND [DeleteDate] IS NULL

  RETURN @@ROWCOUNT
END
GO

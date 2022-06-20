CREATE PROCEDURE [dbo].[ApartmentUpdateStatus] (@ID AS int,
                                                @StatusFK AS int)
AS BEGIN
  UPDATE [dbo].[Apartments]
  SET [StatusFK] = @StatusFK
  WHERE [ID] = @ID AND [DeleteDate] IS NULL

  RETURN @@ROWCOUNT
END
GO

CREATE PROCEDURE [dbo].[PictureMakeRepresentative] (@ID AS int,
                                                    @UpdatedBy AS int)
AS BEGIN
  DECLARE @ApartmentFK AS int = (
    SELECT ALL TOP 1
      [ApartmentFK]
    FROM [dbo].[Pictures]
    where [ID] = @ID
  )

  UPDATE [dbo].[Pictures]
  SET 
    [UpdatedBy]         = @UpdatedBy,
    [UpdateDate]        = GETDATE(),
    [IsRepresentative]  = 0
  WHERE [ApartmentFK] = @ApartmentFK AND [DeleteDate] IS NULL

  UPDATE [dbo].[Pictures]
  SET
    [UpdatedBy]         = @UpdatedBy,
    [UpdateDate]        = GETDATE(),
    [IsRepresentative]  = 1
  WHERE [ID] = @ID AND [DeleteDate] IS NULL

  RETURN @@ROWCOUNT
END
GO

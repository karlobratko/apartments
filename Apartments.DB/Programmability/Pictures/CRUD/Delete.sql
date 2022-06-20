CREATE PROCEDURE [dbo].[PictureDelete] (@ID AS int,
                                        @DeletedBy AS int)
AS BEGIN
  DECLARE @IsRepresentative AS bit
  DECLARE @ApartmentFK AS int

  SELECT ALL TOP 1
    @ApartmentFK = [ApartmentFK],
    @IsRepresentative = [IsRepresentative]
  FROM [dbo].[Pictures]
  WHERE [ID] = @ID AND [DeleteDate] IS NULL

  IF @ApartmentFK IS NULL BEGIN
    RETURN 0
  END

  UPDATE [dbo].[Pictures]
  SET
    [DeletedBy]   = @DeletedBy,
    [DeleteDate]  = GETDATE()
  WHERE [ID] = @ID AND [DeleteDate] IS NULL

  DECLARE @DeletedRows AS int = @@ROWCOUNT

  IF @IsRepresentative = 0 BEGIN
    RETURN @DeletedRows
  END

  DECLARE @NewRepresentativeID AS int = (
    SELECT ALL TOP 1
      [ID]
    FROM [dbo].[Pictures]
    WHERE [ApartmentFK] = @ApartmentFK
    ORDER BY [CreateDate] DESC
  )

  IF @NewRepresentativeID IS NULL BEGIN
    RETURN @DeletedRows
  END

  DECLARE @UpdatedBy AS int = @DeletedBy

  UPDATE [dbo].[Pictures]
  SET 
    [UpdatedBy]         = @UpdatedBy,
    [UpdateDate]        = GETDATE(),
    [IsRepresentative]  = 1
  WHERE [ID] = @NewRepresentativeID
END
GO

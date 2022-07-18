CREATE PROCEDURE [dbo].[PictureMakeRepresentative] (@Guid      AS uniqueidentifier,
                                                    @UpdatedBy AS int = 1)
AS BEGIN
  DECLARE @ApartmentFK AS int = (
    SELECT ALL TOP 1
      [ApartmentFK]
    FROM [dbo].[Pictures]
    WHERE [Guid] = @Guid
  )

  IF @ApartmentFK IS NULL BEGIN
    RETURN -1
  END

  UPDATE [dbo].[Pictures]
  SET 
    [UpdatedBy]         = @UpdatedBy,
    [UpdateDate]        = GETDATE(),
    [IsRepresentative]  = 0
  WHERE [ApartmentFK] = @ApartmentFK AND
        [DeleteDate] IS NULL

  UPDATE [dbo].[Pictures]
  SET
    [UpdatedBy]         = @UpdatedBy,
    [UpdateDate]        = GETDATE(),
    [IsRepresentative]  = 1
  WHERE [DeleteDate] IS NULL AND
        [Guid] = @Guid

  IF @@ROWCOUNT = 1 BEGIN
    RETURN 1
  END
  ELSE BEGIN
    RETURN -1
  END
END
GO

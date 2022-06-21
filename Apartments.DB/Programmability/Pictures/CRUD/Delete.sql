CREATE PROCEDURE [dbo].[PictureDelete] (@Guid      AS uniqueidentifier,
                                        @DeletedBy AS int = 1)
AS BEGIN
  DECLARE @Id AS int
  DECLARE @DeleteDate AS datetime
  SELECT ALL TOP 1
    @Id         = [Id],
    @DeleteDate = [DeleteDate]
  FROM [dbo].[Pictures]
  WHERE [Guid] = @Guid

  IF @Id IS NULL BEGIN
    RETURN 2
  END
  ELSE IF @Id IS NOT NULL AND
          @DeleteDate IS NOT NULL BEGIN
    RETURN 3
  END

  DECLARE @IsRepresentative AS bit
  DECLARE @ApartmentFK      AS int

  SELECT ALL TOP 1
    @ApartmentFK      = [ApartmentFK],
    @IsRepresentative = [IsRepresentative]
  FROM [dbo].[Pictures]
  WHERE [Guid] = @Guid

  UPDATE [dbo].[Pictures]
  SET
    [DeletedBy]   = @DeletedBy,
    [DeleteDate]  = GETDATE()
  WHERE [Guid] = @Guid

  IF @@ROWCOUNT = 1 BEGIN
    DECLARE @NewRepresentativeGuid AS uniqueidentifier = (
      SELECT ALL TOP 1
        [Guid]
      FROM [dbo].[Pictures]
      WHERE [ApartmentFK] = @ApartmentFK
      ORDER BY [CreateDate] DESC
    )

    IF @NewRepresentativeGuid IS NOT NULL BEGIN
      UPDATE [dbo].[Pictures]
      SET 
        [UpdatedBy]         = @DeletedBy,
        [UpdateDate]        = GETDATE(),
        [IsRepresentative]  = 1
      WHERE [Guid] = @NewRepresentativeGuid
    END

    RETURN 1
  END
  ELSE BEGIN
    RETURN -1
  END
END
GO

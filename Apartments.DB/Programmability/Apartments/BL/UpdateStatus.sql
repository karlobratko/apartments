CREATE PROCEDURE [dbo].[ApartmentUpdateStatus] (@Guid      AS uniqueidentifier,
                                                @StatusFK  AS int,
                                                @UpdatedBy AS int)
AS BEGIN
  UPDATE [dbo].[Apartments]
    SET 
      [UpdateDate] = GETDATE(),
      [UpdatedBy]  = @UpdatedBy,
      [StatusFK]   = @StatusFK
  WHERE [DeleteDate] IS NULL AND
        [Guid] = @Guid

  RETURN @@ROWCOUNT
END
GO

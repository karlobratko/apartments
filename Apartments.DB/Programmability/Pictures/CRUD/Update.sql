CREATE PROCEDURE [dbo].[PictureUpdate] (@ID AS int,
                                        @ApartmentFK AS int,
                                        @Name AS nvarchar(100),
                                        @Path AS nvarchar(500),
                                        @IsRepresentative AS bit,
                                        @UpdatedBy AS int)
AS BEGIN
  UPDATE [dbo].[Pictures]
  SET
    [UpdatedBy]         = @UpdatedBy,
    [UpdateDate]        = GETDATE(),
    [ApartmentFK]       = @ApartmentFK,
    [Name]              = @Name,
    [Path]              = @Path,
    [IsRepresentative]  = @IsRepresentative
  WHERE [ID] = @ID AND [DeleteDate] IS NULL

  RETURN @@ROWCOUNT
END
GO

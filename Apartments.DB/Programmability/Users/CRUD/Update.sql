CREATE PROCEDURE [dbo].[UserUpdate] (@ID AS int,
                                     @FName AS nvarchar(50),
                                     @LName AS nvarchar(50),
                                     @Username AS nvarchar(50),
                                     @Email AS nvarchar(256),
                                     @PhoneNumber AS nvarchar(20),
                                     @PasswordHash AS nvarchar(512),
                                     @Address AS nvarchar(200),
                                     @IsAdmin AS bit,
                                     @UpdatedBy AS int)
AS BEGIN
  UPDATE [dbo].[Users]
  SET
    [UpdatedBy]     = @UpdatedBy,
    [UpdateDate]    = GETDATE(),
    [FName]         = @FName,
    [LName]         = @LName,
    [Username]      = @Username,
    [Email]         = @Email,
    [PhoneNumber]   = @PhoneNumber,
    [PasswordHash]  = @PasswordHash,
    [Address]       = @Address,
    [IsAdmin]       = @IsAdmin
  WHERE [ID] = @ID AND [DeleteDate] IS NULL

  RETURN @@ROWCOUNT
END
GO

CREATE PROCEDURE [dbo].[UserCreate] (@FName AS nvarchar(50),
                                     @LName AS nvarchar(50),
                                     @Username AS nvarchar(50),
                                     @Email AS nvarchar(256),
                                     @PhoneNumber AS nvarchar(20),
                                     @PasswordHash AS nvarchar(512),
                                     @Address AS nvarchar(200),
                                     @IsAdmin AS bit,
                                     @CreatedBy AS int)
AS BEGIN
  INSERT INTO [dbo].[Users]
  (
    [CreatedBy],
    [UpdatedBy],
    [FName],
    [LName],
    [Username],
    [Email],
    [PhoneNumber],
    [PasswordHash], 
    [Address],
    [IsAdmin]
  )
  VALUES
  (
    @CreatedBy,
    @CreatedBy,
    @FName,
    @LName,
    @Username,
    @Email,
    @PhoneNumber,
    @PasswordHash,
    @Address,
    @IsAdmin
  )

  RETURN SCOPE_IDENTITY()
END
GO

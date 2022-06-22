CREATE PROCEDURE [dbo].[UserUpdateProfile] (@Guid        AS uniqueidentifier,
                                            @FName       AS nvarchar(50),
                                            @LName       AS nvarchar(50),
                                            @PhoneNumber AS nvarchar(20),
                                            @Address     AS nvarchar(200),
                                            @UpdatedBy   AS int = 1)
AS BEGIN
  UPDATE [dbo].[Users]
  SET
    [UpdatedBy]   = @UpdatedBy,
    [UpdateDate]  = GETDATE(),
    [FName]       = @FName,
    [LName]       = @LName,
    [PhoneNumber] = @PhoneNumber,
    [Address]     = @Address
  WHERE [DeleteDate] IS NULL AND
        [Guid] = @Guid

  IF @@ROWCOUNT = 1 BEGIN
    SELECT ALL
      [Id],
      [Guid],
      [CreateDate],
      [CreatedBy],
      [UpdateDate],
      [UpdatedBy],
      [DeleteDate],
      [DeletedBy],
      [FName],
      [LName],
      [Username],
      [Email],
      [PhoneNumber],
      [PasswordHash],
      [Address],
      [IsAdmin],
      [IsRegistered],
      [RegistrationDate],
      [CanResetPassword],
      [ResetPasswordStartDate]
    FROM [dbo].[Users]
    WHERE [Guid] = @Guid

    RETURN 1
  END
  ELSE BEGIN
    RETURN -1
  END
END

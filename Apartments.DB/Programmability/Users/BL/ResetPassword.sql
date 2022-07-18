CREATE PROCEDURE [dbo].[UserResetPassword] (@Guid      AS uniqueidentifier,
                                            @Password  AS nvarchar(512),
                                            @UpdatedBy AS int = 1)
AS BEGIN
  DECLARE @PasswordHash AS nvarchar(512) = CONVERT(nvarchar(512), HASHBYTES('SHA2_512', @Password), 2)

  DECLARE @UpdateDate AS datetime = GETDATE()

  UPDATE [dbo].[Users]
  SET
    [UpdatedBy]               = @UpdatedBy,
    [UpdateDate]              = @UpdateDate,
    [PasswordHash]            = @PasswordHash,
    [CanResetPassword] = 0
  WHERE [DeleteDate] IS NULL AND
        [Guid] = @Guid AND
        [CanResetPassword] = 1 AND
        DATEDIFF(MINUTE, [ResetPasswordStartDate], GETDATE()) <= 5

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
GO

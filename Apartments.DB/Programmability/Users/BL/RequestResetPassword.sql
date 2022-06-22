CREATE PROCEDURE [dbo].[UserRequestResetPassword] (@Email     AS nvarchar(100),
                                                   @UpdatedBy AS int = 1)
AS BEGIN
  DECLARE @Guid AS uniqueidentifier
  SELECT ALL
    @Guid = [Guid]
  FROM [dbo].[Users]
  WHERE [DeleteDate] IS NULL AND
        [Email] = @Email AND
        [CanResetPassword] = 0 AND
        [IsRegistered] = 1

  DECLARE @ResetPasswordStartDate AS datetime = GETDATE()

  IF @Guid IS NOT NULL BEGIN
    UPDATE [dbo].[Users]
    SET 
      [UpdateDate]             = @ResetPasswordStartDate,
      [UpdatedBy]              = @UpdatedBy,
      [CanResetPassword]       = 1,
      [ResetPasswordStartDate] = @ResetPasswordStartDate
    WHERE [Guid] = @Guid

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
  ELSE IF @Guid IS NULL BEGIN
    RETURN 2
  END
END

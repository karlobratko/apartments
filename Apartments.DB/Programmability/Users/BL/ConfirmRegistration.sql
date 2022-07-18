CREATE PROCEDURE [dbo].[UserConfirmRegistration] (@Guid      AS uniqueidentifier,
                                                  @UpdatedBy AS int = 1)
AS BEGIN
  DECLARE @RegistrationDate AS datetime = GETDATE()

  UPDATE [dbo].[Users]
  SET
    [UpdatedBy]        = @UpdatedBy,
    [UpdateDate]       = @RegistrationDate,
    [IsRegistered]     = 1,
    [RegistrationDate] = @RegistrationDate
  WHERE [DeleteDate] IS NULL AND
        [Guid] = @Guid AND 
        IsRegistered = 0 AND
        DATEDIFF(MINUTE, [CreateDate], GETDATE()) <= 15

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

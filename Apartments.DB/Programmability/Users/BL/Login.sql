CREATE PROCEDURE [dbo].[UserLogin] (@Username AS nvarchar(100),
                                    @Email    AS nvarchar(256),
                                    @Password AS nvarchar(512))
AS BEGIN
  DECLARE @PasswordHash AS nvarchar(512) = CONVERT(nvarchar(512), HASHBYTES('SHA2_512', @Password), 2)

  IF @Username IS NULL BEGIN
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
    WHERE [DeleteDate] IS NULL AND
          [Email] = @Email AND
          [PasswordHash] = @PasswordHash AND
          [IsRegistered] = 1
  END
  ELSE BEGIN
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
    WHERE [DeleteDate] IS NULL AND
          [Username] = @Username AND
          [PasswordHash] = @PasswordHash AND
          [IsRegistered] = 1
  END
END
GO

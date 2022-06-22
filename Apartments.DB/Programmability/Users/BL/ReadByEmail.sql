CREATE PROCEDURE [dbo].[UserReadByEmail] (@Email AS nvarchar(100))
AS BEGIN
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
        [IsRegistered] = 1
END
GO

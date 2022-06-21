CREATE PROCEDURE [dbo].[UserRead] (@Method AS int,
                                   @Guid   AS uniqueidentifier = NULL)
AS BEGIN
  IF @Method = 1 BEGIN
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
  END
  ELSE IF @Method = 2 BEGIN
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
    WHERE [DeleteDate] IS NULL
  END
  ELSE IF @Method = 3 BEGIN
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
  END
  ELSE IF @Method = 4 BEGIN
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
          [Guid] = @Guid
  END
END
GO

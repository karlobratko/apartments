CREATE PROCEDURE [dbo].[UserUpdate] (@Guid                   AS uniqueidentifier,
                                     @FName                  AS nvarchar(50),
                                     @LName                  AS nvarchar(50),
                                     @Username               AS nvarchar(50),
                                     @Email                  AS nvarchar(256),
                                     @PhoneNumber            AS nvarchar(20),
                                     @PasswordHash           AS nvarchar(512),
                                     @Address                AS nvarchar(200),
                                     @IsAdmin                AS bit,
                                     @IsRegistered           AS bit,
                                     @RegistrationDate       AS datetime,
                                     @CanResetPassword       AS bit,
                                     @ResetPasswordStartDate AS datetime,
                                     @UpdatedBy              AS int = 1)
AS BEGIN
  DECLARE @Id         AS int
  DECLARE @DeleteDate AS datetime
  SELECT ALL TOP 1
    @Id         = [Id],
    @DeleteDate = [DeleteDate]
  FROM [dbo].[Users]
  WHERE [Guid] = @Guid

  IF @Id IS NULL BEGIN
    RETURN 2
  END
  ELSE IF @Id IS NOT NULL AND
          @DeleteDate IS NOT NULL BEGIN
    RETURN 3
  END

  SET @Id         = NULL
  SET @DeleteDate = NULL

  SELECT ALL TOP 1
    @Id         = [Id],
    @DeleteDate = [DeleteDate]
  FROM [dbo].[Users]
  WHERE ([Username] = @Username OR
         [Email]    = @Email) AND
        [Guid] <> @Guid

  IF @Id IS NOT NULL AND
     @DeleteDate IS NULL BEGIN
    RETURN 4
  END
  ELSE IF @Id IS NOT NULL AND
          @DeleteDate IS NOT NULL BEGIN
    RETURN 3
  END

  UPDATE [dbo].[Users]
  SET
    [UpdatedBy]              = @UpdatedBy,
    [UpdateDate]             = GETDATE(),
    [FName]                  = @FName,
    [LName]                  = @LName,
    [Username]               = @Username,
    [Email]                  = @Email,
    [PhoneNumber]            = @PhoneNumber,
    [PasswordHash]           = @PasswordHash,
    [Address]                = @Address,
    [IsAdmin]                = @IsAdmin,
    [IsRegistered]           = @IsRegistered,
    [RegistrationDate]       = @RegistrationDate,
    [CanResetPassword]       = @CanResetPassword,
    [ResetPasswordStartDate] = @ResetPasswordStartDate
  WHERE [Guid] = @Guid

  IF @@ROWCOUNT = 1 BEGIN
    RETURN 1
  END
  ELSE BEGIN
    RETURN -1
  END
END
GO

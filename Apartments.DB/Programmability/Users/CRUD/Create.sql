CREATE PROCEDURE [dbo].[UserCreate] (@FName                  AS nvarchar(50),
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
                                     @CreatedBy              AS int = 1)
AS BEGIN
  DECLARE @Guid       AS uniqueidentifier
  DECLARE @DeleteDate AS datetime
  SELECT ALL TOP 1
    @Guid       = [Guid],
    @DeleteDate = [DeleteDate]
  FROM [dbo].[Users]
  WHERE [Username] = @Username OR
        [Email]    = @Email

  IF @Guid IS NULL BEGIN
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
      [IsAdmin],
      [IsRegistered],
      [RegistrationDate],
      [CanResetPassword],
      [ResetPasswordStartDate]
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
      @IsAdmin,
      @IsRegistered,
      @RegistrationDate,
      @CanResetPassword,
      @ResetPasswordStartDate
    )

    DECLARE @Id AS int = SCOPE_IDENTITY()
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
    WHERE [Id] = @Id

    RETURN 1
  END
  ELSE IF @Guid       IS NOT NULL AND 
          @DeleteDate IS NOT NULL BEGIN
    SET @Guid = NULL
    SET @Guid = (
      SELECT ALL TOP 1
        [Guid]
      FROM [dbo].[Users]
      WHERE [Username] = @Username AND
            [Email]    = @Email
    )
    IF @Guid IS NOT NULL BEGIN
      UPDATE [dbo].[Users]
      SET
        [DeleteDate]             = NULL,
        [DeletedBy]              = NULL,
        [UpdateDate]             = GETDATE(),
        [UpdatedBy]              = @CreatedBy,
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

      RETURN 3
    END
    ELSE BEGIN
      RETURN 2
    END
  END
  ELSE IF @Guid       IS NOT NULL AND 
          @DeleteDate IS NULL BEGIN
    UPDATE [dbo].[Users]
    SET
      [UpdateDate] = GETDATE(),
      [UpdatedBy]  = @CreatedBy
    WHERE [Guid] = @Guid

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

    RETURN 2
  END
  ELSE BEGIN
    RETURN -1
  END
END
GO

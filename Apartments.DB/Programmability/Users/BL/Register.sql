CREATE PROCEDURE [dbo].[UserRegister] (@FName     AS nvarchar(50),
                                       @LName     AS nvarchar(50),
                                       @Username  AS nvarchar(50),
                                       @Email     AS nvarchar(256),
                                       @Password  AS nvarchar(512),
                                       @IsAdmin   AS bit,
                                       @CreatedBy AS int = 1)
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
    DECLARE @PasswordHash AS nvarchar(512) = CONVERT(nvarchar(512), HASHBYTES('SHA2_512', @Password), 2)

    INSERT INTO [dbo].[Users]
    (
      [CreatedBy],
      [UpdatedBy],
      [FName],
      [LName],
      [Username],
      [Email],
      [PasswordHash],
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
      @PasswordHash,
      @IsAdmin
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
    RETURN 3
  END
  ELSE IF @Guid       IS NOT NULL AND 
          @DeleteDate IS NULL BEGIN
    RETURN 2
  END
  ELSE BEGIN
    RETURN -1
  END
END
GO

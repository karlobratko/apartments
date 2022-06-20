CREATE PROCEDURE [dbo].[UserRegister] (@FName AS nvarchar(50),
                                       @LName AS nvarchar(50),
                                       @Username AS nvarchar(50),
                                       @Email AS nvarchar(256),
                                       @PhoneNumber AS nvarchar(20),
                                       @Password AS nvarchar(512),
                                       @IsAdmin AS bit)
AS BEGIN
  DECLARE @PasswordHash AS nvarchar(512) = CONVERT(nvarchar(512), HASHBYTES('SHA2_512', @Password), 2)
  DECLARE @CreatedBy AS int = (
    SELECT ALL TOP 1
      [ID]
    FROM [dbo].[Users]
    WHERE [ID] = [CreatedBy] AND
          [IsAdmin] = 1
    ORDER BY [CreateDate]
  )

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
    @PhoneNumber,
    @PasswordHash,
    @IsAdmin
  )

  DECLARE @ID AS int = SCOPE_IDENTITY()

  SELECT ALL TOP 1
    [ID],
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
    [IsAdmin]
  FROM [dbo].[Users]
  WHERE [ID] = @ID AND
        [DeleteDate] IS NULL
END
GO
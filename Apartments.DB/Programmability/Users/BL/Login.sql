CREATE PROCEDURE [dbo].[UserLogin] (@Username AS nvarchar(50),
                                    @Password AS nvarchar(512))
AS BEGIN
  DECLARE @PasswordHash AS nvarchar(512) = CONVERT(nvarchar(512), HASHBYTES('SHA2_512', @Password), 2)

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
  WHERE [Username] = @Username AND 
        [PasswordHash] = @PasswordHash AND 
        [DeleteDate] IS NULL
END
GO
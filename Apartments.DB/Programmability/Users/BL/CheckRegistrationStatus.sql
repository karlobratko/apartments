CREATE PROCEDURE [dbo].[UserCheckRegistrationStatus] (@Guid AS uniqueidentifier)
AS BEGIN
  DECLARE @RecordExists AS int = (
    SELECT ALL TOP 1
      COUNT(*)
    FROM [dbo].[Users]
    WHERE [Guid] = @Guid
  )
  
  IF @RecordExists = 0 BEGIN
    RETURN 2
  END
  ELSE BEGIN
    DECLARE @CreateDate   AS datetime
    DECLARE @IsRegistered AS bit

    SELECT ALL TOP 1
      @CreateDate   = [CreateDate],
      @IsRegistered = [IsRegistered]
    FROM [dbo].[Users]
    WHERE [GUID] = @GUID

    DECLARE @PassedTime AS int = DATEDIFF(MINUTE, @CreateDate, GETDATE())

    IF @PassedTime <= 15 BEGIN
      IF  @IsRegistered = 0 BEGIN
        RETURN 1
      END
      ELSE BEGIN
        RETURN 3
      END
    END
    ELSE BEGIN
      RETURN 4
    END
  END
END
GO
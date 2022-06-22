CREATE PROCEDURE [dbo].[UserCheckResetPasswordStatus] (@Guid AS uniqueidentifier)
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
    DECLARE @ResetPasswordStartDate  AS datetime
    DECLARE @CanResetPassword        AS bit

    SELECT ALL TOP 1
      @ResetPasswordStartDate = [ResetPasswordStartDate],
      @CanResetPassword       = [CanResetPassword]
    FROM [dbo].[Users]
    WHERE [Guid] = @Guid

    DECLARE @PassedTime AS int = DATEDIFF(MINUTE, @ResetPasswordStartDate, GETDATE())

    IF @PassedTime <= 5 BEGIN
      IF @CanResetPassword = 1 BEGIN
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

CREATE PROCEDURE [dbo].[ReservationUpdate] (@Guid            AS uniqueidentifier,
                                            @ApartmentFK     AS int,
                                            @Details         AS nvarchar(500),
                                            @UserFK          AS int,
                                            @UserFName       AS nvarchar(50),
                                            @UserLName       AS nvarchar(50),
                                            @UserEmail       AS nvarchar(256),
                                            @UserPhoneNumber AS nvarchar(20),
                                            @UserAddress     AS nvarchar(200),
                                            @UpdatedBy       AS int = 1)
AS BEGIN
  DECLARE @Id         AS int
  DECLARE @DeleteDate AS datetime
  SELECT ALL TOP 1
    @Id         = [Id],
    @DeleteDate = [DeleteDate]
  FROM [dbo].[Reservations]
  WHERE [Guid] = @Guid

  IF @Id IS NULL BEGIN
    RETURN 2
  END
  ELSE IF @Id IS NOT NULL AND
          @DeleteDate IS NOT NULL BEGIN
    RETURN 3
  END

  UPDATE [dbo].[Reservations]
  SET
    [UpdatedBy]       = @UpdatedBy,
    [UpdateDate]      = GETDATE(),
    [ApartmentFK]     = @ApartmentFK,
    [Details]         = @Details,
    [UserFK]          = @UserFK,
    [UserFName]       = @UserFName,
    [UserLName]       = @UserLName,
    [UserEmail]       = @UserEmail,
    [UserPhoneNumber] = @UserPhoneNumber,
    [UserAddress]     = @UserAddress
  WHERE [Guid] = @Guid

  IF @@ROWCOUNT = 1 BEGIN
    RETURN 1
  END
  ELSE BEGIN
    RETURN -1
  END
END
GO

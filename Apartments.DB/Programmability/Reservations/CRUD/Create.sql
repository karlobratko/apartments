CREATE PROCEDURE [dbo].[ReservationCreate] (@ApartmentFK     AS int,
                                            @Details         AS nvarchar(500),
                                            @UserFK          AS int,
                                            @UserFName       AS nvarchar(50),
                                            @UserLName       AS nvarchar(50),
                                            @UserEmail       AS nvarchar(256),
                                            @UserPhoneNumber AS nvarchar(20),
                                            @UserAddress     AS nvarchar(200),
                                            @CreatedBy       AS int = 1)
AS BEGIN
  INSERT INTO [dbo].[Reservations]
  (
    [CreatedBy],
    [UpdatedBy],
    [ApartmentFK],
    [Details],
    [UserFK],
    [UserFName],
    [UserLName],
    [UserEmail],
    [UserPhoneNumber],
    [UserAddress]
  )
  VALUES
  (
    @CreatedBy,
    @CreatedBy,
    @ApartmentFK,
    @Details,
    @UserFK,
    @UserFName,
    @UserLName,
    @UserEmail,
    @UserPhoneNumber,
    @UserAddress
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
    [ApartmentFK],
    [Details],
    [UserFK],
    [UserFName],
    [UserLName],
    [UserEmail],
    [UserPhoneNumber],
    [UserAddress]
  FROM [dbo].[Reservations]
  WHERE [Id] = @Id

  RETURN 1
END
GO

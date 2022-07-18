CREATE PROCEDURE [dbo].[ReservationsRead] (@Method AS int,
                                           @Id     AS int = NULL)
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
      [ApartmentFK],
      [Details],
      [UserFK],
      [UserFName],
      [UserLName],
      [UserEmail],
      [UserPhoneNumber],
      [UserAddress]
    FROM [dbo].[Reservations]
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
      [ApartmentFK],
      [Details],
      [UserFK],
      [UserFName],
      [UserLName],
      [UserEmail],
      [UserPhoneNumber],
      [UserAddress]
    FROM [dbo].[Reservations]
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
      [ApartmentFK],
      [Details],
      [UserFK],
      [UserFName],
      [UserLName],
      [UserEmail],
      [UserPhoneNumber],
      [UserAddress]
    FROM [dbo].[Reservations]
    WHERE [DeleteDate] IS NULL AND
          [Id] = @Id
  END
END
GO

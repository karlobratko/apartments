CREATE PROCEDURE [dbo].[ReservationsRead] (@Method AS int,
                                           @Guid   AS uniqueidentifier = NULL)
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
    WHERE [Guid] = @Guid
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
          [Guid] = @Guid
  END
END
GO

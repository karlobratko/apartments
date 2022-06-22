CREATE PROCEDURE [dbo].[ReviewRead] (@Method AS int,
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
      [UserFK],
      [Details],
      [Stars]
    FROM [dbo].[Reviews]
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
      [UserFK],
      [Details],
      [Stars]
    FROM [dbo].[Reviews]
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
      [UserFK],
      [Details],
      [Stars]
    FROM [dbo].[Reviews]
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
      [UserFK],
      [Details],
      [Stars]
    FROM [dbo].[Reviews]
    WHERE [DeleteDate] IS NULL AND
          [Guid] = @Guid
  END
END
GO

CREATE PROCEDURE [dbo].[ReviewReadByApartmentFK] (@ApartmentFK AS int)
AS BEGIN
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
        [ApartmentFK] = @ApartmentFK
  ORDER BY [CreateDate] DESC
END
GO

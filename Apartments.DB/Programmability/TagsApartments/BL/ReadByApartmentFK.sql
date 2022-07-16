CREATE PROCEDURE [dbo].[TagApartmentReadByApartmentFK] (@ApartmentFK AS int)
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
    [TagFK],
    [ApartmentFK]
  FROM [dbo].[TagsApartments]
  WHERE [DeleteDate] IS NULL AND
        [ApartmentFK] = @ApartmentFK
END
GO
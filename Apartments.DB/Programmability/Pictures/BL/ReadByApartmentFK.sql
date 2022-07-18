CREATE PROCEDURE [dbo].[PictureReadByApartmentFK] (@ApartmentFK AS int)
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
    [Title],
    [Data],
    [MimeType],
    [IsRepresentative]
  FROM [dbo].[Pictures]
  WHERE [DeleteDate] IS NULL AND
        [ApartmentFK] = @ApartmentFK
END
GO

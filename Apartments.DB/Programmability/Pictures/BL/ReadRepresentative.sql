CREATE PROCEDURE [dbo].[PictureReadRepresentative] (@ApartmentFK AS int)
AS BEGIN
  SELECT ALL TOP 1
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
        [ApartmentFK] = @ApartmentFK AND
        [IsRepresentative] = 1
END
GO

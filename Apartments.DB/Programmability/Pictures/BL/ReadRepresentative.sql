CREATE PROCEDURE [dbo].[PictureReadRepresentative] (@ApartmentFK AS int)
AS BEGIN
  SELECT ALL TOP 1
    [Id],
    [CreateDate],
    [CreatedBy],
    [UpdateDate],
    [UpdatedBy],
    [DeleteDate],
    [DeletedBy],
    [ApartmentFK],
    [Title],
    [Path],
    [IsRepresentative]
  FROM [dbo].[Pictures]
  WHERE [DeleteDate] IS NULL AND
        [ApartmentFK] = @ApartmentFK AND
        [IsRepresentative] = 1
END
GO

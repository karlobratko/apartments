CREATE PROCEDURE [dbo].[PictureReadByApartmentFK] (@ApartmentFK AS int)
AS BEGIN
  SELECT ALL
    [ID],
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
  WHERE [ApartmentFK] = @ApartmentFK AND [DeleteDate] IS NULL
  ORDER BY [CreateDate] DESC
END
GO

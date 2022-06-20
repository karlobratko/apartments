CREATE PROCEDURE [dbo].[PictureRead] (@ID AS int = NULL)
AS BEGIN
  IF @ID IS NULL BEGIN
    SELECT ALL
      [ID],
      [CreateDate],
      [CreatedBy],
      [UpdateDate],
      [UpdatedBy],
      [DeleteDate],
      [DeletedBy],
      [ApartmentFK],
      [Name],
      [Path],
      [IsRepresentative]
    FROM [dbo].[Pictures]
    WHERE [DeleteDate] IS NULL
    ORDER BY [CreateDate] DESC
  END
  ELSE BEGIN
    SELECT ALL
      [ID],
      [CreateDate],
      [CreatedBy],
      [UpdateDate],
      [UpdatedBy],
      [DeleteDate],
      [DeletedBy],
      [ApartmentFK],
      [Name],
      [Path],
      [IsRepresentative]
    FROM [dbo].[Pictures]
    WHERE [ID] = @ID AND [DeleteDate] IS NULL
  END
END
GO

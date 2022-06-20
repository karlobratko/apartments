CREATE PROCEDURE [dbo].[StatusRead] (@ID AS int = NULL)
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
      [Name],
      [NameEng]
    FROM [dbo].[Statuses]
    WHERE [DeleteDate] IS NULL
    ORDER BY [Name] ASC
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
      [Name],
      [NameEng]
    FROM [dbo].[Statuses]
    WHERE [ID] = @ID AND [DeleteDate] IS NULL
  END
END
GO

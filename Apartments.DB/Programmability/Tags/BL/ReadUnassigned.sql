CREATE PROCEDURE [dbo].[TagReadUnassigned] (@ApartmentFK AS int)
AS BEGIN
  SELECT ALL
    [ID],
    [CreateDate],
    [CreatedBy],
    [UpdateDate],
    [UpdatedBy],
    [DeleteDate],
    [DeletedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  FROM [dbo].[Tags]
  WHERE [DeleteDate] IS NULL AND
        [ID] NOT IN (
          SELECT DISTINCT
            [TagFK]
          FROM [dbo].[TagsApartments]
          WHERE [ApartmentFK] = @ApartmentFK
        )
  ORDER BY [Name] ASC
END
GO

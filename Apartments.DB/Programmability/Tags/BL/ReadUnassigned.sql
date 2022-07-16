CREATE PROCEDURE [dbo].[TagReadUnassigned] (@ApartmentFK AS int)
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
    [Name],
    [NameEng],
    [TagTypeFK]
  FROM [dbo].[Tags]
  WHERE [DeleteDate] IS NULL AND
        [Id] NOT IN (
          SELECT DISTINCT
            [TagFK]
          FROM [dbo].[TagsApartments]
          WHERE [ApartmentFK] = @ApartmentFK AND
                [DeleteDate] IS NULL
        )
END
GO

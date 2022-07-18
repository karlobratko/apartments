CREATE PROCEDURE [dbo].[TagReadByApartmentFK] (@ApartmentFK AS int)
AS BEGIN
  SELECT ALL
    [Tags].[Id],
    [Tags].[Guid],
    [Tags].[CreateDate],
    [Tags].[CreatedBy],
    [Tags].[UpdateDate],
    [Tags].[UpdatedBy],
    [Tags].[DeleteDate],
    [Tags].[DeletedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  FROM [dbo].[Tags]
    INNER JOIN [dbo].[TagsApartments]
      ON [Tags].[Id] = [TagsApartments].[TagFK]
  WHERE [Tags].[DeleteDate] IS NULL AND
        [TagsApartments].[DeleteDate] IS NULL AND
        [ApartmentFK] = @ApartmentFK
END
GO

CREATE PROCEDURE [dbo].[MetadataRead]
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
    [Name],
    [OIB],
    [CityFK],
    [Address],
    [Telephone],
    [Mobile],
    [Email]
  FROM [dbo].[Metadata]
END
GO
﻿CREATE PROCEDURE [dbo].[TagApartmentRead] (@Method AS int,
                                           @Guid   AS uniqueidentifier = NULL)
AS BEGIN
IF @Method = 1 BEGIN
    SELECT ALL
      [Id],
      [Guid],
      [CreateDate],
      [CreatedBy],
      [UpdateDate],
      [UpdatedBy],
      [DeleteDate],
      [DeletedBy],
      [TagFK],
      [ApartmentFK]
    FROM [dbo].[TagsApartments]
  END
  ELSE IF @Method = 2 BEGIN
    SELECT ALL
      [Id],
      [Guid],
      [CreateDate],
      [CreatedBy],
      [UpdateDate],
      [UpdatedBy],
      [DeleteDate],
      [DeletedBy],
      [TagFK],
      [ApartmentFK]
    FROM [dbo].[TagsApartments]
    WHERE [DeleteDate] IS NULL
  END
  ELSE IF @Method = 3 BEGIN
    SELECT ALL
      [Id],
      [Guid],
      [CreateDate],
      [CreatedBy],
      [UpdateDate],
      [UpdatedBy],
      [DeleteDate],
      [DeletedBy],
      [TagFK],
      [ApartmentFK]
    FROM [dbo].[TagsApartments]
    WHERE [Guid] = @Guid
  END
  ELSE IF @Method = 4 BEGIN
    SELECT ALL
      [Id],
      [Guid],
      [CreateDate],
      [CreatedBy],
      [UpdateDate],
      [UpdatedBy],
      [DeleteDate],
      [DeletedBy],
      [TagFK],
      [ApartmentFK]
    FROM [dbo].[TagsApartments]
    WHERE [DeleteDate] IS NULL AND
          [Guid] = @Guid
  END
END
GO
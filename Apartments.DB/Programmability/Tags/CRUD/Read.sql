CREATE PROCEDURE [dbo].[TagRead] (@Method AS int,
                                  @Id     AS int = NULL)
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
      [Name],
      [NameEng],
      [TagTypeFK]
    FROM [dbo].[Tags]
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
      [Name],
      [NameEng],
      [TagTypeFK]
    FROM [dbo].[Tags]
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
      [Name],
      [NameEng],
      [TagTypeFK]
    FROM [dbo].[Tags]
    WHERE [Id] = @Id
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
      [Name],
      [NameEng],
      [TagTypeFK]
    FROM [dbo].[Tags]
    WHERE [DeleteDate] IS NULL AND
          [Id] = @Id
  END
END
GO

-- USERS [ADMIN]

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Users] WHERE [Email] = N'admin' AND [Username] = N'admin') BEGIN
  ALTER TABLE [Users] NOCHECK CONSTRAINT [FK_Users_CreatedBy]
  ALTER TABLE [Users] NOCHECK CONSTRAINT [FK_Users_UpdatedBy]
  ALTER TABLE [Users] NOCHECK CONSTRAINT [FK_Users_DeletedBy]

  DECLARE @Password AS nvarchar(512) = N'513e04f4e8e7da39578d165a06eb8129f80a2d2674acf598b12ef247fa445badc7b04806deee6e0cfd913d19227c4ba84713ba165be0458425bff06c053f3a35'

  INSERT INTO [dbo].[Users] 
  (
    [CreatedBy], 
    [UpdatedBy], 
    [FName], 
    [LName], 
    [Username],
    [Email], 
    [PhoneNumber],
    [PasswordHash], 
    [IsAdmin],
    [IsRegistered],
    [RegistrationDate]
  )
  VALUES 
  (
    1, 
    1, 
    N'admin', 
    N'admin', 
    N'admin', 
    N'admin', 
    N'00000000000000000000',
    CONVERT(nvarchar(512), HASHBYTES('SHA2_512', @Password), 2), 
    1,
    1,
    GETDATE()
  )

  ALTER TABLE [Users] CHECK CONSTRAINT [FK_Users_CreatedBy]
  ALTER TABLE [Users] CHECK CONSTRAINT [FK_Users_UpdatedBy]
  ALTER TABLE [Users] CHECK CONSTRAINT [FK_Users_DeletedBy]
END
GO

-- OWNERS

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Owners] WHERE [Name] = 'Filip Trn') BEGIN
  INSERT INTO [dbo].[Owners]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name]
  )
  VALUES
  (
    1,
    1,
    'Filip Trn'
  )
END

-- CITIES

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Cities] WHERE [Name] = 'Zagreb') BEGIN
  INSERT INTO [dbo].[Cities]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name]
  )
  VALUES
  (
    1,
    1,
    'Zagreb'
  )
END

-- STATUSES

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Statuses] WHERE [Name] = 'Dostupno' AND [NameEng] = 'Available') BEGIN
  INSERT INTO [dbo].[Statuses]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng]
  )
  VALUES
  (
    1,
    1,
    'Dostupno',
    'Available'
  )
END

-- APARTMENTS

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Apartments] WHERE [Name] = 'Crni Biser' AND [NameEng] = 'Black Pearl') BEGIN
    INSERT INTO [dbo].[Apartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [OwnerFK],
    [StatusFK],
    [Name],
    [NameEng],
    [CityFK],
    [Address],
    [Price],
    [MaxAdults],
    [MaxChildren],
    [TotalRooms],
    [BeachDistance]
  )
  VALUES
  (
    1,
    1,
    1,
    1,
    'Crni Biser',
    'Black Pearl',
    1,
    'Ilica 127',
    350.00,
    2,
    3,
    15,
    100
  )
END

-- TAG TYPES

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagTypes] WHERE [Name] = 'Kupaona' AND [NameEng] = 'Bathroom') BEGIN
  INSERT INTO [dbo].[TagTypes]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng]
  )
  VALUES
  (
    1,
    1,
    'Kupaona',
    'Bathroom'
  )
END
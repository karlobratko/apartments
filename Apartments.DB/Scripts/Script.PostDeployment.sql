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

-- USERS
IF NOT EXISTS (SELECT ALL * FROM [dbo].[Users] WHERE [Email] = N'kbratko@gmail.com' AND [Username] = N'kbratko') BEGIN
  DECLARE @Password AS nvarchar(512) = N'pass'
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
    N'Karlo', 
    N'Bratko', 
    N'kbratko', 
    N'kbratko@gmail.com', 
    N'0915584572',
    CONVERT(nvarchar(512), HASHBYTES('SHA2_512', @Password), 2), 
    1,
    1,
    GETDATE()
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Users] WHERE [Email] = N'gbratko@gmail.com' AND [Username] = N'gbratko') BEGIN
  DECLARE @Password AS nvarchar(512) = N'pass'
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
    N'Gordana', 
    N'Bratko', 
    N'gbratko', 
    N'gbratko@gmail.com', 
    N'0914234341',
    CONVERT(nvarchar(512), HASHBYTES('SHA2_512', @Password), 2), 
    0,
    1,
    GETDATE()
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Users] WHERE [Email] = N'dbratko@gmail.com' AND [Username] = N'dbratko') BEGIN
  DECLARE @Password AS nvarchar(512) = N'pass'
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
    N'Drago', 
    N'Bratko', 
    N'dbratko', 
    N'dbratko@gmail.com', 
    N'0914336341',
    CONVERT(nvarchar(512), HASHBYTES('SHA2_512', @Password), 2), 
    0,
    1,
    GETDATE()
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Users] WHERE [Email] = N'isimic@gmail.com' AND [Username] = N'isimic') BEGIN
  DECLARE @Password AS nvarchar(512) = N'pass'
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
    N'Ilija', 
    N'Šimić', 
    N'isimic', 
    N'isimic@gmail.com', 
    N'0917736341',
    CONVERT(nvarchar(512), HASHBYTES('SHA2_512', @Password), 2), 
    0,
    1,
    GETDATE()
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Users] WHERE [Email] = N'ihorvat@gmail.com' AND [Username] = N'ihorvat') BEGIN
  DECLARE @Password AS nvarchar(512) = N'pass'
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
    N'Ivan', 
    N'Horvat', 
    N'ihorvat', 
    N'ihorvat@gmail.com', 
    N'0911132641',
    CONVERT(nvarchar(512), HASHBYTES('SHA2_512', @Password), 2), 
    0,
    1,
    GETDATE()
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Users] WHERE [Email] = N'jmraz@gmail.com' AND [Username] = N'jmraz') BEGIN
DECLARE @Password AS nvarchar(512) = N'pass'
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
    N'Jan', 
    N'Mraz', 
    N'jmraz', 
    N'jmraz@gmail.com', 
    N'0919932331',
    CONVERT(nvarchar(512), HASHBYTES('SHA2_512', @Password), 2), 
    0,
    1,
    GETDATE()
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Users] WHERE [Email] = N'dtkalcec@gmail.com' AND [Username] = N'dtkalcec') BEGIN
DECLARE @Password AS nvarchar(512) = N'pass'
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
    N'Dejan', 
    N'Tkalčec', 
    N'dtkalcec', 
    N'dtkalcec@gmail.com', 
    N'0919235353',
    CONVERT(nvarchar(512), HASHBYTES('SHA2_512', @Password), 2), 
    0,
    1,
    GETDATE()
  )
END
GO

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
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Cities] WHERE [Name] = 'Rijeka') BEGIN
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
    'Rijeka'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Cities] WHERE [Name] = 'Split') BEGIN
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
    'Split'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Cities] WHERE [Name] = 'Dubrovnik') BEGIN
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
    'Dubrovnik'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Cities] WHERE [Name] = 'Pula') BEGIN
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
    'Pula'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Cities] WHERE [Name] = N'Omiš') BEGIN
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
    N'Omiš'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Cities] WHERE [Name] = N'Zadar') BEGIN
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
    N'Zadar'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Cities] WHERE [Name] = N'Šibenik') BEGIN
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
    N'Šibenik'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Cities] WHERE [Name] = N'Čakovec') BEGIN
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
    N'Čakovec'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Cities] WHERE [Name] = N'Sinj') BEGIN
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
    N'Sinj'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Cities] WHERE [Name] = N'Rovinj') BEGIN
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
    N'Rovinj'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Cities] WHERE [Name] = N'Trogir') BEGIN
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
    N'Trogir'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Cities] WHERE [Name] = N'Opatija') BEGIN
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
    N'Opatija'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Cities] WHERE [Name] = N'Karlobag') BEGIN
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
    N'Karlobag'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Cities] WHERE [Name] = N'Crikvenica') BEGIN
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
    N'Crikvenica'
  )
END
GO

-- METADATA

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Metadata]) BEGIN
  INSERT INTO [dbo].[Metadata]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [OIB],
    [CityFK],
    [Address],
    [Telephone],
    [Mobile],
    [Email]
  )
  VALUES
  (
    1,
    1,
    'Apartments',
    '43091233291',
    1,
    'Ilica, 127',
    '040856064',
    '0915584572',
    'karlobratko@gmail.com'
  )
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
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Owners] WHERE [Name] = 'Matija Cvek') BEGIN
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
    'Matija Cvek'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Owners] WHERE [Name] = 'Josip Horvat') BEGIN
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
    'Josip Horvat'
  )
END
GO

-- STATUSES

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Statuses] WHERE [Name] = 'Slobodno' AND [NameEng] = 'Vacant') BEGIN
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
    'Slobodno',
    'Vacant'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Statuses] WHERE [Name] = 'Rezervirano' AND [NameEng] = 'Reserved') BEGIN
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
    'Rezervirano',
    'Reserved'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Statuses] WHERE [Name] = 'Zauzeto' AND [NameEng] = 'Occupied') BEGIN
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
    'Zauzeto',
    'Not available'
  )
END
GO

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
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Apartments] WHERE [Name] = 'Meteor' AND [NameEng] = 'Metheorite') BEGIN
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
    3,
    2,
    'Meteor',
    'Metheorite',
    3,
    'Ilijina ulica 12',
    500.00,
    3,
    4,
    40,
    100
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Apartments] WHERE [Name] = 'San' AND [NameEng] = 'Dream') BEGIN
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
    2,
    1,
    'San',
    'Dream',
    3,
    'Cvijetna ulica 3',
    300.00,
    3,
    4,
    40,
    120
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Apartments] WHERE [Name] = 'Zlatni pijesak' AND [NameEng] = 'Golden sand') BEGIN
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
    3,
    1,
    'Zlatni pijesak',
    'Golden sand',
    4,
    'Slana ulica 8',
    399.99,
    2,
    2,
    10,
    40
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Apartments] WHERE [Name] = N'Crvena ruža' AND [NameEng] = 'Red rose') BEGIN
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
    N'Crvena ruža',
    'Red rose',
    5,
    'Ulica pod lipom 7',
    300.99,
    2,
    4,
    10,
    240
  )
END

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Apartments] WHERE [Name] = 'Plava laguna' AND [NameEng] = 'Blue laguna') BEGIN
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
    3,
    1,
    'Plava laguna',
    'Blue laguna',
    5,
    'Slana ulica 8',
    430.99,
    2,
    2,
    10,
    30
  )
END
GO
GO

-- TAG TYPES

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagTypes] WHERE [Name] = 'Aparati' AND [NameEng] = 'Devices') BEGIN
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
    'Aparati',
    'Devices'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagTypes] WHERE [Name] = 'Područja' AND [NameEng] = 'Areas') BEGIN
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
    'Područja',
    'Areas'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagTypes] WHERE [Name] = 'Ostalo' AND [NameEng] = 'Other') BEGIN
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
    'Ostalo',
    'Other'
  )
END
GO

-- TAGS

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = 'Kafe aparat' AND [NameEng] = 'Coffee maker') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    'Kafe aparat',
    'Coffee maker',
    1
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = 'Kuhalo' AND [NameEng] = 'Electric kettle') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    'Kuhalo',
    'Electric kettle',
    1
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = N'Sušilo za kosu' AND [NameEng] = 'Hairdryer') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    N'Sušilo za kosu',
    'Hairdryer',
    1
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = N'Mikrovalna pećnica' AND [NameEng] = 'Microwave') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    N'Mikrovalna pećnica',
    'Microwave',
    1
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = N'Pećnica' AND [NameEng] = 'Oven') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    N'Pećnica',
    'Oven',
    1
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = 'Hladnjak' AND [NameEng] = 'Refrigerator') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    'Hladnjak',
    'Refrigerator',
    1
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = 'TV' AND [NameEng] = 'TV') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    'TV',
    'TV',
    1
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = N'Aparat za čaj' AND [NameEng] = 'Tea maker') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    N'Aparat za čaj',
    'Tea maker',
    1
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = 'Toster' AND [NameEng] = 'Toaster') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    'Toster',
    'Toaster',
    1
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = 'Perilica za rublje' AND [NameEng] = 'Washing machine') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    'Perilica za rublje',
    'Washing machine',
    1
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = 'Balkon' AND [NameEng] = 'Balcony') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    'Balkon',
    'Balcony',
    2
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = 'Kupaonica' AND [NameEng] = 'Bathroom') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    'Kupaonica',
    'Bathroom',
    2
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = 'Vrtni prostor' AND [NameEng] = 'Garden area') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    'Vrtni prostor',
    'Garden area',
    2
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = 'Kuhinja' AND [NameEng] = 'Kitchen') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    'Kuhinja',
    'Kitchen',
    2
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = N'Otvoreno dvorište' AND [NameEng] = 'Patio') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    N'Otvoreno dvorište',
    'Patio',
    2
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = 'Terasa' AND [NameEng] = 'Terrace') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    'Terasa',
    'Terrace',
    2
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = 'Zahod' AND [NameEng] = 'Toilet') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    'Zahod',
    'Toilet',
    2
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = 'Bazen' AND [NameEng] = 'Swimming Pool') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    'Bazen',
    'Swimming Pool',
    2
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = N'Stalak za sušenje odjeće' AND [NameEng] = 'Clothes drying rack') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    N'Stalak za sušenje odjeće',
    'Clothes drying rack',
    3
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = N'Bade-mantil' AND [NameEng] = 'Bathrobe') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    N'Bade-mantil',
    'Bathrobe',
    3
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = N'Tepisi' AND [NameEng] = 'Carpets') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    N'Tepisi',
    'Carpets',
    3
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = N'Posteljina' AND [NameEng] = 'Linens') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    N'Posteljina',
    'Linens',
    3
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = N'Ručnici' AND [NameEng] = 'Towels') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    N'Ručnici',
    'Towels',
    3
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = N'Kada' AND [NameEng] = 'Bathtub') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    N'Kada',
    'Bathtub',
    3
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = N'Tuš' AND [NameEng] = 'Shower') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    N'Tuš',
    'Shower',
    3
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = N'Bide' AND [NameEng] = 'Bidet') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    N'Bide',
    'Bidet',
    3
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Tags] WHERE [Name] = N'Sredstva za čišćenje' AND [NameEng] = 'Cleaning products') BEGIN
  INSERT INTO [dbo].[Tags]
  (
    [CreatedBy],
    [UpdatedBy],
    [Name],
    [NameEng],
    [TagTypeFK]
  )
  VALUES
  (
    1,
    1,
    N'Sredstva za čišćenje',
    'Cleaning products',
    3
  )
END
GO

-- TAGS APARTMENTS

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 1 AND [ApartmentFK] = 3) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    1,
    3
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 3 AND [ApartmentFK] = 1) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    3,
    1
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 14 AND [ApartmentFK] = 1) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    10,
    1
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 16 AND [ApartmentFK] = 1) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    14,
    1
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 7 AND [ApartmentFK] = 1) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    5,
    1
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 2 AND [ApartmentFK] = 2) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    2,
    2
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 4 AND [ApartmentFK] = 2) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    4,
    2
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 6 AND [ApartmentFK] = 2) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    6,
    2
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 8 AND [ApartmentFK] = 2) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    8,
    2
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 15 AND [ApartmentFK] = 2) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    13,
    2
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 3 AND [ApartmentFK] = 3) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    3,
    3
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 6 AND [ApartmentFK] = 3) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    6,
    3
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 9 AND [ApartmentFK] = 3) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    9,
    3
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 13 AND [ApartmentFK] = 1) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    13,
    1
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 7 AND [ApartmentFK] = 1) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    7,
    1
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 21 AND [ApartmentFK] = 1) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    21,
    1
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 4 AND [ApartmentFK] = 1) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    4,
    1
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 14 AND [ApartmentFK] = 2) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    14,
    2
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 11 AND [ApartmentFK] = 3) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    11,
    3
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 19 AND [ApartmentFK] = 3) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    19,
    3
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 3 AND [ApartmentFK] = 4) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    3,
    4
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 2 AND [ApartmentFK] = 4) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    2,
    4
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 8 AND [ApartmentFK] = 4) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    8,
    4
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 11 AND [ApartmentFK] = 4) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    11,
    4
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 15 AND [ApartmentFK] = 4) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    15,
    4
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 6 AND [ApartmentFK] = 4) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    6,
    4
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 7 AND [ApartmentFK] = 4) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    7,
    4
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 3 AND [ApartmentFK] = 5) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    3,
    5
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 6 AND [ApartmentFK] = 5) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    6,
    5
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 9 AND [ApartmentFK] = 5) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    9,
    5
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 2 AND [ApartmentFK] = 5) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    2,
    5
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 19 AND [ApartmentFK] = 5) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    19,
    5
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 24 AND [ApartmentFK] = 5) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    24,
    5
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 27 AND [ApartmentFK] = 5) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    27,
    5
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 21 AND [ApartmentFK] = 5) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    21,
    5
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 4 AND [ApartmentFK] = 6) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    4,
    6
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 7 AND [ApartmentFK] = 6) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    7,
    6
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 27 AND [ApartmentFK] = 6) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    27,
    6
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 24 AND [ApartmentFK] = 6) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    24,
    6
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 17 AND [ApartmentFK] = 6) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    17,
    6
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 20 AND [ApartmentFK] = 6) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    20,
    6
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[TagsApartments] WHERE [TagFK] = 12 AND [ApartmentFK] = 6) BEGIN
  INSERT INTO [dbo].[TagsApartments]
  (
    [CreatedBy],
    [UpdatedBy],
    [TagFK],
    [ApartmentFK]
  )
  VALUES
  (
    1,
    1,
    12,
    6
  )
END
GO

-- REVIEWS

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Reviews] WHERE [UserFK] = 3 AND [ApartmentFK] = 1) BEGIN
  INSERT INTO [dbo].[Reviews]
  (
    [CreatedBy],
    [UpdatedBy],
    [UserFK],
    [ApartmentFK],
    [Stars],
    [Details]
  )
  VALUES
  (
    1,
    1,
    3,
    1,
    4,
    'Apartman je jako uredan'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Reviews] WHERE [UserFK] = 4 AND [ApartmentFK] = 1) BEGIN
  INSERT INTO [dbo].[Reviews]
  (
    [CreatedBy],
    [UpdatedBy],
    [UserFK],
    [ApartmentFK],
    [Stars],
    [Details]
  )
  VALUES
  (
    1,
    1,
    4,
    1,
    5,
    'Osoblje je jako pristojno'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Reviews] WHERE [UserFK] = 5 AND [ApartmentFK] = 1) BEGIN
  INSERT INTO [dbo].[Reviews]
  (
    [CreatedBy],
    [UpdatedBy],
    [UserFK],
    [ApartmentFK],
    [Stars],
    [Details]
  )
  VALUES
  (
    1,
    1,
    5,
    1,
    4,
    'Osoblje je jako pristojno'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Reviews] WHERE [UserFK] = 6 AND [ApartmentFK] = 1) BEGIN
  INSERT INTO [dbo].[Reviews]
  (
    [CreatedBy],
    [UpdatedBy],
    [UserFK],
    [ApartmentFK],
    [Stars],
    [Details]
  )
  VALUES
  (
    1,
    1,
    6,
    1,
    5,
    'More je jako čisto'
  )
END
GO

IF NOT EXISTS (SELECT ALL * FROM [dbo].[Reviews] WHERE [UserFK] = 7 AND [ApartmentFK] = 1) BEGIN
  INSERT INTO [dbo].[Reviews]
  (
    [CreatedBy],
    [UpdatedBy],
    [UserFK],
    [ApartmentFK],
    [Stars],
    [Details]
  )
  VALUES
  (
    1,
    1,
    7,
    1,
    5,
    'Ležaljke su jako udobne'
  )
END
GO
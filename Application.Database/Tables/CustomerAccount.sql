CREATE TABLE [dbo].[CustomerAccount]
(
	[Id] INT identity (100, 1) NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [EmailAddress] NVARCHAR(50) NULL, 
    [Phone] NCHAR(25) NULL, 
 --   [UserId] UNIQUEIDENTIFIER NULL,
	--CONSTRAINT Fk_ApsNetUsers FOREIGN KEY (UserId)
	--REFERENCES dbo.AspNetUsers(Id)
)

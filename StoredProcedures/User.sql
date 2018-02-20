USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetAllUsers]
GO

CREATE PROCEDURE [dbo].[sp_GetAllUsers] AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM Users

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
----------------------------------------------------------
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetUserById]
GO

CREATE PROCEDURE [dbo].[sp_GetUserById]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Users WHERE Id = @Id

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
----------------------------------------------------------
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetUserByEmail]
GO

CREATE PROCEDURE [dbo].[sp_GetUserByEmail]
	@Email nvarchar(64)
AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Users WHERE Email = @Email

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
----------------------------------------------------------
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_CreateUser]
GO

CREATE PROCEDURE [dbo].[sp_CreateUser]
	@Address nvarchar(300),
    @BirthDay date,
	@Email nvarchar(64),
	@FullName nvarchar(300),
	@Image nvarchar(2000),
	@Password nvarchar(512),
	@PhoneNumber nvarchar(10),
	@Sex nvarchar(3),
	@RoleId int
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].Users (Address, BirthDay, Email, FullName, Image, Password, PhoneNumber, Sex, RoleId)
    VALUES (@Address, @BirthDay, @Email, @FullName, @Image, @Password, @PhoneNumber, @Sex, @RoleId)

	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
----------------------------------------------------------
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_UpdateUser]
GO

CREATE PROCEDURE [dbo].[sp_UpdateUser]
	@Address nvarchar(300),
    @BirthDay date,
	@Email nvarchar(64),
	@FullName nvarchar(300),
	@Image nvarchar(2000),
	@Password nvarchar(512),
	@PhoneNumber nvarchar(10),
	@Sex nvarchar(3),
	@RoleId int,
	@Id int
AS

IF NOT EXISTS (SELECT 1 FROM Users WHERE Id=@Id)
BEGIN
	RETURN -1
END

BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].Users
		SET	[Address] = @Address, [BirthDay] = @BirthDay, [Email] = @Email, [FullName] = @FullName,
			[Image] = @Image, [Password] = @Password, [PhoneNumber] = @PhoneNumber, [Sex] = @Sex, [RoleId] = @RoleId
		WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
----------------------------------------------------------
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_DeleteUser]
GO

CREATE PROCEDURE [dbo].[sp_DeleteUser]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;
	
	DELETE FROM Users WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO

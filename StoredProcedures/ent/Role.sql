USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetAllRoles]
GO

CREATE PROCEDURE [dbo].[sp_GetAllRoles] 
AS
BEGIN
	SET NOCOUNT ON;

    SELECT * FROM Roles
END
GO
----------------------------------------------------------
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetRoleById]
GO

CREATE PROCEDURE [dbo].[sp_GetRoleById]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Roles WHERE Id = @id
END
GO
----------------------------------------------------------
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetRoleByName]
GO

CREATE PROCEDURE [dbo].[sp_GetRoleByName]
	@Name nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Roles WHERE Name = @Name
END
GO
----------------------------------------------------------
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_CreateRole]
GO

CREATE PROCEDURE [dbo].[sp_CreateRole]
	@Name nvarchar(50)
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Roles] (Name) VALUES (@Name)
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

DROP PROCEDURE IF EXISTS [dbo].[sp_UpdateRole]
GO

CREATE PROCEDURE [dbo].[sp_UpdateRole]
	@Name nvarchar(30),
	@Id int
AS

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Id=@Id)
BEGIN
	RETURN -1
END

BEGIN TRY	
	SET NOCOUNT ON;

	UPDATE [dbo].Roles SET
		[Name] = @Name WHERE Id = @Id

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

DROP PROCEDURE IF EXISTS [dbo].[sp_DeleteRole]
GO

CREATE PROCEDURE [dbo].[sp_DeleteRole]
	@id int
AS
BEGIN TRY
	SET NOCOUNT ON;

	DELETE FROM Roles WHERE Id = @id
	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO

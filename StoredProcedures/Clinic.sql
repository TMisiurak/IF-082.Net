USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateClinic]    Script Date: 31.01.2018 22:44:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreateClinic]
	@Name nvarchar(200),
	@Address nvarchar(300)
AS
BEGIN TRY
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Clinics] (Name, Address) VALUES (@Name, @Address)
	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO


USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteClinic]    Script Date: 31.01.2018 23:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteClinic]
	@id int
AS
BEGIN TRY
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Clinics WHERE Id = @id
	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO


USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllClinics]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Clinics
END
GO


USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetClinicById]
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [dbo].Clinics WHERE Id = @id
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP PROCEDURE IF EXISTS [dbo].[sp_UpdateClinic]
GO
CREATE PROCEDURE [dbo].[sp_UpdateClinic]
	@Address nvarchar(MAX),
	@Name nvarchar(MAX),
	@Id int
AS
IF NOT EXISTS (SELECT 1 FROM Clinics WHERE Id=@Id)
BEGIN
	RETURN -1
END
BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].Clinics SET
	[Address] = @Address, [Name] = @Name
	WHERE Id = @Id
	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_CreatePatient]
GO

CREATE PROCEDURE [dbo].[sp_CreatePatient]
	@UserId int
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Patients] (UserId) VALUES (@UserId)

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
CREATE PROCEDURE [dbo].[sp_DeletePatient]
	@id int
AS
BEGIN TRY
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Patients WHERE Id = @id
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
CREATE PROCEDURE [dbo].[sp_GetAllPatients]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Patients
END
GO

USE [ClinicDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPatientById]
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [dbo].Patients WHERE Id = @id
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sp_UpdatePatient]
	@UserId int,
	@Id int
AS
IF NOT EXISTS (SELECT 1 FROM Patients WHERE Id=@Id)
BEGIN
	RETURN -1
END
BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].Patients SET
	[UserId]=@UserId
	WHERE Id = @Id
	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
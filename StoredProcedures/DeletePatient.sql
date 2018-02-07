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

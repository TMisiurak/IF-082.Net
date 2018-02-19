USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteDoctor]    Script Date: 18.02.2018 23:37:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteDoctor]
	@id int
AS
BEGIN TRY
	SET NOCOUNT ON;

	DELETE FROM Doctors WHERE Id = @id
	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH

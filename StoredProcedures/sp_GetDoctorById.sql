USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDoctorById]    Script Date: 18.02.2018 23:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetDoctorById]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].Doctors WHERE Id = @Id

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH

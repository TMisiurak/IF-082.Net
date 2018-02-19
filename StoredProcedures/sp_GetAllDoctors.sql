USE [ClinicDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllDoctors]    Script Date: 18.02.2018 23:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAllDoctors] AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[Doctors]

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
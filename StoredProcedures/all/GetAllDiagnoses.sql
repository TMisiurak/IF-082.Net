USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetAllDiagnoses]
GO

CREATE PROCEDURE [dbo].[sp_GetAllDiagnoses] AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[Diagnoses]

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO

USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_CreateDiagnosis]
GO

CREATE PROCEDURE [dbo].[sp_CreateDiagnosis]
	@DiagnosisName nvarchar(100)
	, @Description nvarchar(4000)
    
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Diagnoses] (DiagnosisName, Description)
    VALUES (@DiagnosisName, @Description)

	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO

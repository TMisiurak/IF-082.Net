USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_UpdateDiagnosis]
GO

CREATE PROCEDURE [dbo].[sp_UpdateDiagnosis]
	@Id int
	, @DiagnosisName nvarchar(100)
	, @Description nvarchar(4000)
	
AS

IF NOT EXISTS (SELECT 1 FROM Diagnosis WHERE Id=@Id)
BEGIN
	RETURN -1
END

BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].[Diagnosis]
		SET	[DiagnosisName] = @DiagnosisName
		, [Description] = @Description
		WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO

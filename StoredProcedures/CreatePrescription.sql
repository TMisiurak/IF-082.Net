USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_CreatePrescription]
GO

CREATE PROCEDURE [dbo].[sp_CreatePrescription]
    @Date datetime,
	@Description nvarchar(4000),
	@DiagnosisId int,
	@DoctorId int,
	@PatientId int
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].Prescriptions ([Date], [Description], DiagnosisId, DoctorId, PatientId)
    VALUES (@Date, @Description, @DiagnosisId, @DoctorId, @PatientId)

	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO

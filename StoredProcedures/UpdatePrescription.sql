USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_UpdatePrescription]
GO

CREATE PROCEDURE [dbo].[sp_UpdatePrescription]
	@Id int,
	@Date datetime,
	@Description nvarchar(4000),
	@DiagnosisId int,
	@DoctorId int,
	@PatientId int
AS

IF NOT EXISTS (SELECT 1 FROM Prescriptions WHERE Id=@Id)
BEGIN
	RETURN -1
END

BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].Prescriptions
		SET	[Date] = @Date, [Description] = @Description, [DiagnosisId] = @DiagnosisId,
			DoctorId = @DoctorId, [PatientId] = @PatientId
		WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO

USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_UpdateAppointment]
GO

CREATE PROCEDURE [dbo].[sp_UpdateAppointment]
	@Id int
	, @PatientId int
	, @DoctorId int
	, @Description nvarchar(4000)
	, @Date datetime
	, @Status int
	, @CabinetId int
	, @PrescriptionId int
	
AS

IF NOT EXISTS (SELECT 1 FROM Appointments WHERE Id=@Id)
BEGIN
	RETURN -1
END

BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].[Appointments]
		SET	[PatientId] = @PatientId
		, [DoctorId] = @DoctorId
		, [Description] = @Description
		, [Date] = @Date
		, [Status] = @Status
		, [CabinetId] = @CabinetId
		, [PrescriptionId] = @PrescriptionId
		WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO

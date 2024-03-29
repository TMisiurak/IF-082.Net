USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetAppointmentByDoctorId]
GO

CREATE PROCEDURE [dbo].[sp_GetAppointmentByDoctorId]
	@DoctorId int
AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[Appointments] WHERE DoctorId = @DoctorId

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO

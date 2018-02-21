USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetScheduleByDoctorId]
GO

CREATE PROCEDURE [dbo].[sp_GetScheduleByDoctorId]
	@DoctorId int
AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT S.*, A.Date AS AssignedTimeSlot FROM (SELECT * FROM [dbo].Schedules WHERE DoctorId = @DoctorId) S LEFT JOIN (SELECT DATE FROM [dbo].Appointments WHERE DoctorId = @DoctorId) A On S.Weekday = DATEPART(WEEKDAY, A.Date) - 1
	
	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
----------------------------------------------------------

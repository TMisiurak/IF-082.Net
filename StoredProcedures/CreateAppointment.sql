USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_CreateAppointment]
GO

CREATE PROCEDURE [dbo].[sp_CreateAppointment]
	@PatientId int
	, @DoctorId int
	, @Description nvarchar(4000)
	, @Date datetime
	, @Status int
    
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Appointments] (PatientId, DoctorId, Description, Date, Status)
    VALUES (@PatientId, @DoctorId, @Description, @Date, @Status)

	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
